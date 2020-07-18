using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;
using Dapper;
using MySql.Data.MySqlClient;
using Xunit.Abstractions;

namespace ColinChang.DapperHelper.Test
{
    public class DapperHelperTest : IClassFixture<DapperFixture>
    {
        private readonly DapperHelper<MySqlConnection> _dapper;
        private readonly ITestOutputHelper _testOutputHelper;

        public DapperHelperTest(DapperFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _dapper = fixture.Dapper;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task InsertTest()
        {
            const string sql = "INSERT INTO author (NickName,RealName) VALUES(@nickName,@RealName)";
            var affected = await _dapper.ExecuteAsync(sql,
                new[] {new Author("三儿", "张三"), new Author("四儿", "李四")});

            Assert.Equal(2, affected);
        }

        [Fact]
        public async Task UpdateTest()
        {
            const string sql = "UPDATE author SET Address=@address WHERE Id=@id";
            var affected = await _dapper.ExecuteAsync(sql, new {id = 1, address = "山东"});

            Assert.Equal(1, affected);
        }

        [Fact]
        public async Task DeleteTest()
        {
            const string sql = "DELETE FROM author WHERE Id=@id";
            var affected = await _dapper.ExecuteAsync(sql, new {id = 3});

            Assert.Equal(0, affected);
        }

        [Fact]
        public async Task QueryScalarTest()
        {
            const string sql = "SELECT COUNT(1) FROM author WHERE Id=@id AND NickName=@nickName";
            var cnt = await _dapper.QueryScalarAsync(sql, new {id = 1, nickName = "Colin"});

            Assert.Equal(1, Convert.ToInt32(cnt));
        }

        [Fact]
        public async Task SimpleQueryTest()
        {
            const string sql = "SELECT * FROM author WHERE Id=@id";
            var authors = await _dapper.QueryAsync<Author>(sql, new {id = 1});

            Assert.NotNull(authors.FirstOrDefault());
        }

        [Fact]
        public async Task InQueryTest()
        {
            const string sql = "SELECT * FROM author WHERE Id IN @ids";
            var authors = await _dapper.QueryAsync<Author>(sql, new {ids = new[] {1, 2}});

            Assert.Equal(2, authors.Count());
        }

        [Fact]
        public async Task JoinQueryTest()
        {
            const string sql = @"SELECT * FROM
                article AS ar
                JOIN author AS au ON ar.AuthorId = au.Id
                LEFT JOIN `comment` AS c ON ar.Id = c.ArticleId";
            var articles = new Dictionary<int, Article>();
            var data = await _dapper.QueryAsync<Article, Author, Comment, Article>(sql,
                (article, author, comment) =>
                {
                    //1:1
                    article.Author = author;

                    //1:N
                    if (!articles.TryGetValue(article.Id, out var articleEntry))
                    {
                        articleEntry = article;
                        articleEntry.Comments = new List<Comment>();
                        articles.Add(article.Id, articleEntry);
                    }

                    articleEntry.Comments = articleEntry.Comments.Append(comment);
                    return articleEntry;
                });
            var result1 = data.Distinct();
            var result2 = articles.Values;

            Assert.Equal(result1.Count(), result2.Count());
        }

        [Fact]
        public async Task JsonMultiQueryTest()
        {
            const string sql1 = "SELECT * FROM article WHERE Id=@id";
            const string sql2 = "SELECT * FROM `comment` WHERE ArticleId=@articleId";
            var data = await _dapper.QueryMultipleAsync(new[] {sql1, sql2}, new {id = 1, articleId = 1});
            var article = data.ElementAt(0).ElementAt(0).ToString(); //Json

            Assert.NotEmpty(article);
        }

        [Fact]
        public async Task MultiQueryTest()
        {
            var sqls = new[]
            {
                "SELECT * FROM article WHERE Id=@id",
                "SELECT * FROM `comment` WHERE ArticleId=@articleId"
            };
            var (articles, comments) =
                await _dapper.QueryMultipleAsync<Article, Comment>(sqls, new {id = 1, articleId = 1});
            var article = articles.FirstOrDefault();

            Assert.NotNull(article);
            article.Comments = comments;

            Assert.True(article.Comments.Any());
        }

        [Fact]
        public async Task TransactionTest()
        {
            var affected = await _dapper.ExecuteTransactionAsync(new[]
            {
                new SqlScript("UPDATE article SET UpdateTime=NOW() WHERE Id=@id", new {id = 2}),
                new SqlScript("UPDATE author SET BirthDate=NOW() WHERE Id=@id", new {id = 1})
            });

            Assert.Equal(2, affected);
        }

        [Fact]
        public async Task TransactionWithOperationTest()
        {
            var affected = _dapper.ExecuteTransaction(async cnn =>
            {
                await cnn.ExecuteAsync("UPDATE article SET `Status`=2 WHERE Id=1");
                var current = await cnn.QueryAsync<Author>("SELECT * FROM author WHERE Id=1 FOR UPDATE");
            
                _testOutputHelper.WriteLine(current.FirstOrDefault()?.RealName);
                throw new Exception("test rollback transaction");
            
                return await cnn.ExecuteAsync("UPDATE author SET NickName='Colin Chang' WHERE Id=1");
            });
            
            var res= await affected;
            Assert.Equal(1, await affected);
        }
    }

    public class DapperFixture : IDisposable
    {
        private readonly string _connStr = "Server=127.0.0.1;Database=dapper;Uid=root;Pwd=123123;";

        public DapperFixture()
        {
            Dapper = new DapperHelper<MySqlConnection>(_connStr);
            ResetAsync().Wait();
        }

        public DapperHelper<MySqlConnection> Dapper { get; }

        public async void Dispose() =>
            await ResetAsync();

        private async Task ResetAsync()
        {
            var sqls = new[]
            {
                "TRUNCATE article",
                "TRUNCATE author",
                "TRUNCATE `comment`",
                "INSERT INTO `article` VALUES (1, '.NET从入门到放弃', 'just give it up', 1, '2020-07-18 15:25:08', 1)",
                "INSERT INTO `article` VALUES (2, 'C++从放弃到忘记', 'what the hell is C++', 1, '2020-07-18 15:25:39', 1)",
                "INSERT INTO `article` VALUES (3, 'Python药不能停', '快醒醒，你还有俩bug没修', 1, '2020-07-18 15:26:20', 2)",
                "INSERT INTO `author` VALUES (1, 'Colin', 'ColinChang', '1990-10-24', 'Beijing China')",
                "INSERT INTO `author` VALUES (2, 'Robin', 'RobinSong', '1990-09-07', 'ZhengZhou China')",
                "INSERT INTO `comment` VALUES (1, 1, '燃', '2020-07-18 15:26:35')",
                "INSERT INTO `comment` VALUES (2, 1, 'Exactly', '2020-07-18 15:26:51')",
                "INSERT INTO `comment` VALUES (3, 2, 'Totally', '2020-07-18 15:27:04')",
                "INSERT INTO `comment` VALUES (4, 2, '一针见血', '2020-07-18 15:27:51')",
                "INSERT INTO `comment` VALUES (5, 3, '睡了睡了', '2020-07-18 15:28:07')"
            };
            await Dapper.ExecuteTransactionAsync(sqls.Select(s => new SqlScript(s)));
        }
    }
}
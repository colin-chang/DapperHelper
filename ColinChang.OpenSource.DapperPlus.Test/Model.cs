using System;
using System.Collections.Generic;

namespace ColinChang.OpenSource.DapperPlus.Test
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }

    public class Author : BaseModel
    {
        public string NickName { get; set; }

        public string RealName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public Author() { }

        public Author(string nickName, string realName)
        {
            NickName = nickName;
            RealName = realName;
        }
    }

    public class Article : BaseModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public ArticleStatus Status { get; set; }

        public DateTime UpdateTime { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }

    public enum ArticleStatus
    {
        Abnormal,
        Normal
    }

    public class Comment : BaseModel
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
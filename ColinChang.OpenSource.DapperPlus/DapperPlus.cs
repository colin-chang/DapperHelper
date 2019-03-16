using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public class DapperPlus<TConnection>
        where TConnection:IDbConnection,new()
    {
        private  readonly string _connStr;
        private IDbConnection Cnn
        {
            get
            {
                var cn = new TConnection {ConnectionString = _connStr};
                return cn;
            }
        }


        public DapperPlus(string connectionString)
        {
            _connStr = connectionString;
        }

        /// <summary>
        /// Execute a non-query command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                return cnn.Execute(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute a non-query command asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                return await cnn.ExecuteAsync(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        public object QueryScalar(string sql, object param = null, CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                return cnn.ExecuteScalar(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute parameterized SQL asynchronously that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        public async Task<object> QueryScalarAsync(string sql, object param = null,
            CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                return await cnn.ExecuteScalarAsync(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute a query.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <param name="buffered"></param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType? commandType = null,
            bool buffered = true)
            where T : class, new()
        {
            using (var cnn = Cnn)
            {
                return cnn.Query<T>(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Execute a query asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <param name="buffered"></param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null,
            CommandType? commandType = null, bool buffered = true)
            where T : class, new()
        {
            using (var cnn = Cnn)
            {
                return await cnn.QueryAsync<T>(sql, param, commandType: commandType);
            }
        }

        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
            where TFirst : class, new()
            where TSecond : class, new()
            where TReturn : class, new()
        {
            using (var cnn = Cnn)
            {
                return cnn.Query(sql, map, param, commandType: commandType,
                    buffered: buffered);
            }
        }

        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
            where TFirst : class, new()
            where TSecond : class, new()
            where TReturn : class, new()
        {
            using (var cnn = Cnn)
            {
                return await cnn.QueryAsync(sql, map, param, commandType: commandType,
                    buffered: buffered);
            }
        }

        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
            where TFirst : class, new()
            where TSecond : class, new()
            where TThird : class, new()
            where TReturn : class, new()
        {
            using (var cnn = Cnn)
            {
                return cnn.Query(sql, map, param, commandType: commandType,
                    buffered: buffered);
            }
        }

        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
        /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
        /// <typeparam name="TThird">The third type in the recordset.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
            where TFirst : class, new()
            where TSecond : class, new()
            where TThird : class, new()
            where TReturn : class, new()
        {
            using (var cnn = Cnn)
            {
                return await cnn.QueryAsync(sql, map, param, commandType: commandType,
                    buffered: buffered);
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets</returns>
        public IEnumerable<IEnumerable<object>> QueryMultiple(IEnumerable<string> sqls, object param = null,
            CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                var reader = cnn.QueryMultiple(string.Join(";", sqls), param, commandType: commandType);
                var results = new IEnumerable<object>[sqls.Count()];
                for (var i = 0; i < sqls.Count(); i++)
                    results[i] = reader.Read();

                return results;
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets</returns>
        public async Task<IEnumerable<IEnumerable<object>>> QueryMultipleAsync(IEnumerable<string> sqls,
            object param = null, CommandType? commandType = null)
        {
            using (var cnn = Cnn)
            {
                var reader = await cnn.QueryMultipleAsync(string.Join(";", sqls), param, commandType: commandType);
                var results = new IEnumerable<object>[sqls.Count()];
                for (var i = 0; i < sqls.Count(); i++)
                    results[i] = await reader.ReadAsync();

                return results;
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="TFirst">The type of the first sql recordset.</typeparam>
        /// <typeparam name="TSecond">The type of the second sql recordset.</typeparam>
        /// <returns>Multiple result sets</returns>
        public (IEnumerable<TFirst> Result1, IEnumerable<TSecond> Result2) QueryMultiple<TFirst, TSecond>(
            IEnumerable<string> sqls, object param = null, CommandType? commandType = null)
            where TFirst : class, new()
            where TSecond : class, new()
        {
            using (var cnn = Cnn)
            {
                var reader = cnn.QueryMultiple(string.Join(";", sqls), param, commandType: commandType);
                var result1 = reader.Read<TFirst>();
                var result2 = reader.Read<TSecond>();

                return (result1, result2);
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="TFirst">The type of the first sql recordset.</typeparam>
        /// <typeparam name="TSecond">The type of the second sql recordset.</typeparam>
        /// <returns>Multiple result sets</returns>
        public async Task<(IEnumerable<TFirst> Result1, IEnumerable<TSecond> Result2)>
            QueryMultipleAsync<TFirst, TSecond>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
            where TFirst : class, new()
            where TSecond : class, new()
        {
            using (var cnn = Cnn)
            {
                var reader = await cnn.QueryMultipleAsync(string.Join(";", sqls), param, commandType: commandType);
                var result1 = await reader.ReadAsync<TFirst>();
                var result2 = await reader.ReadAsync<TSecond>();

                return (result1, result2);
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="TFirst">The type of the first sql recordset.</typeparam>
        /// <typeparam name="TSecond">The type of the second sql recordset.</typeparam>
        /// <typeparam name="TThird">The type of the third sql recordset.</typeparam>
        /// <returns>Multiple result sets</returns>
        public (IEnumerable<TFirst> Result1, IEnumerable<TSecond> Result2, IEnumerable<TThird> Result3)
            QueryMultiple<TFirst, TSecond, TThird>(string sqls, object param = null, CommandType? commandType = null)
            where TFirst : class, new()
            where TSecond : class, new()
            where TThird : class, new()
        {
            using (var cnn = Cnn)
            {
                var reader = cnn.QueryMultiple(sqls, param, commandType: commandType);
                var result1 = reader.Read<TFirst>();
                var result2 = reader.Read<TSecond>();
                var result3 = reader.Read<TThird>();

                return (result1, result2, result3);
            }
        }

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="TFirst">The type of the first sql recordset.</typeparam>
        /// <typeparam name="TSecond">The type of the second sql recordset.</typeparam>
        /// <typeparam name="TThird">The type of the third sql recordset.</typeparam>
        /// <returns>Multiple result sets</returns>
        public async
            Task<(IEnumerable<TFirst> Result1, IEnumerable<TSecond> Result2, IEnumerable<TThird> Result3)>
            QueryMultipleAsync<TFirst, TSecond, TThird>(string sqls, object param = null,
                CommandType? commandType = null)
            where TFirst : class, new()
            where TSecond : class, new()
            where TThird : class, new()
        {
            using (var cnn = Cnn)
            {
                var reader = await cnn.QueryMultipleAsync(sqls, param, commandType: commandType);
                var result1 = await reader.ReadAsync<TFirst>();
                var result2 = await reader.ReadAsync<TSecond>();
                var result3 = await reader.ReadAsync<TThird>();

                return (result1, result2, result3);
            }
        }

        /// <summary>
        /// Execute a nonquery transaction.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteTransaction(IEnumerable<SqlScript> scripts)
        {
            using (var cnn = Cnn)
            {
                var count = 0;
                IDbTransaction tran = null;
                try
                {
                    cnn.Open();
                    tran = cnn.BeginTransaction();
                    foreach (var script in scripts)
                        count += cnn.Execute(script.Sql, script.Param, tran, commandType: script.CommandType);

                    tran.Commit();
                    return count;
                }
                catch
                {
                    tran?.Rollback();
                    return count;
                }
            }
        }

        /// <summary>
        /// Execute a nonquery transaction asynchronously.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        public async Task<int> ExecuteTransactionAsync(IEnumerable<SqlScript> scripts)
        {
            using (var cnn = Cnn)
            {
                var count = 0;
                IDbTransaction tran = null;
                try
                {
                    cnn.Open();
                    tran = cnn.BeginTransaction();
                    foreach (var script in scripts)
                        count += await cnn.ExecuteAsync(script.Sql, script.Param, tran,
                            commandType: script.CommandType);

                    tran.Commit();
                    return count;
                }
                catch
                {
                    tran?.Rollback();
                    return count;
                }
            }
        }
    }
    
    public class SqlScript
    {
        public string Sql { get; set; }
        public object Param { get; set; }
        public CommandType CommandType { get; set; }

        public SqlScript(string sql, object param = null, CommandType cmdType = CommandType.Text)
        {
            Sql = sql;
            Param = param;
            CommandType = cmdType;
        }
    }
}

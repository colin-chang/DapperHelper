using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Dapper
{
    public class DapperHelper<TConnection> : IDapperHelper
        where TConnection : IDbConnection, new()
    {
        private readonly string _connStr;

        private IDbConnection Cnn => new TConnection {ConnectionString = _connStr};

        public DapperHelper(string connectionString) => _connStr = connectionString;

        public DapperHelper(IOptions<DapperHelperOptions> options) =>
            _connStr = options.Value.ConnectionString;


        public int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.Execute(sql, param, commandType: commandType);
        }


        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.ExecuteAsync(sql, param, commandType: commandType);
        }


        public object QueryScalar(string sql, object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.ExecuteScalar(sql, param, commandType: commandType);
        }


        public async Task<object> QueryScalarAsync(string sql, object param = null,
            CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.ExecuteScalarAsync(sql, param, commandType: commandType);
        }


        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.Query<T>(sql, param, commandType: commandType);
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null,
            CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryAsync<T>(sql, param, commandType: commandType);
        }


        public IEnumerable<TReturn> Query<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
        {
            using var cnn = Cnn;
            return cnn.Query(sql, map, param, commandType: commandType,
                buffered: buffered);
        }


        public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
        {
            using var cnn = Cnn;
            return await cnn.QueryAsync(sql, map, param, commandType: commandType,
                buffered: buffered);
        }


        public IEnumerable<TReturn> Query<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
        {
            using var cnn = Cnn;
            return cnn.Query(sql, map, param, commandType: commandType,
                buffered: buffered);
        }


        public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true)
        {
            using var cnn = Cnn;
            return await cnn.QueryAsync(sql, map, param, commandType: commandType,
                buffered: buffered);
        }


        public IEnumerable<IEnumerable<object>> QueryMultiple(IEnumerable<string> sqls, object param = null,
            CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple(sqls, param, commandType);
        }


        public async Task<IEnumerable<IEnumerable<object>>> QueryMultipleAsync(IEnumerable<string> sqls,
            object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2) QueryMultiple<T1, T2>(
            IEnumerable<string> sqls, object param = null, CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2>(sqls, param, commandType);
        }


        public async Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2)>
            QueryMultipleAsync<T1, T2>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3)
            QueryMultiple<T1, T2, T3>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3)>
            QueryMultipleAsync<T1, T2, T3>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4)
            QueryMultiple<T1, T2, T3, T4>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4)>
            QueryMultipleAsync<T1, T2, T3, T4>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5)
            QueryMultiple<T1, T2, T3, T4, T5>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5)>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6)
            QueryMultiple<T1, T2, T3, T4, T5, T6>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5, T6>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8, IEnumerable<T9> Result9)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(sqls, param, commandType);
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8, IEnumerable<T9> Result9)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(sqls, param, commandType);
        }


        public (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8, IEnumerable<T9> Result9, IEnumerable<T10> Result10)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return cnn.QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(sqls, param, commandType);
        }


        public SqlMapper.GridReader QueryMultipleReader(IEnumerable<string> sqls,
            object param = null,
            CommandType? commandType = null)
        {
            var cnn = Cnn;
            try
            {
                return cnn.QueryMultiple(sqls.Concat(), param, commandType: commandType);
            }
            catch
            {
                cnn.Close();
                cnn.Dispose();
                throw;
            }
        }


        public async Task<SqlMapper.GridReader> QueryMultipleReaderAsync(IEnumerable<string> sqls,
            object param = null,
            CommandType? commandType = null)
        {
            var cnn = Cnn;
            try
            {
                return await cnn.QueryMultipleAsync(sqls.Concat(), param, commandType: commandType);
            }
            catch
            {
                cnn.Close();
                cnn.Dispose();
                throw;
            }
        }


        public async
            Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8, IEnumerable<T9> Result9, IEnumerable<T10> Result10)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null)
        {
            using var cnn = Cnn;
            return await cnn.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(sqls, param, commandType);
        }


        public int ExecuteTransaction(IEnumerable<SqlScript> scripts)
        {
            var cnn = Cnn;
            var count = 0;
            IDbTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                count += scripts.Sum(script =>
                    cnn.Execute(script.Sql, script.Param, tran, commandType: script.CommandType));

                tran.Commit();
                return count;
            }
            catch
            {
                tran?.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
            }
        }


        public async Task<int> ExecuteTransactionAsync(IEnumerable<SqlScript> scripts)
        {
            var cnn = Cnn;
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
                throw;
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
            }
        }


        public void ExecuteTransaction(Action<IDbConnection> transaction)
        {
            var cnn = Cnn;
            IDbTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                if (transaction.Method.IsDefined(typeof(AsyncStateMachineAttribute), false))
                    throw new NotSupportedException(
                        "asynchronous Action<IDbConnection> is not awaitable nor supported, please use Func<IDbConnection,Task> instead");
                transaction(cnn);
                tran.Commit();
            }
            catch
            {
                tran?.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
            }
        }


        public TResult ExecuteTransaction<TResult>(Func<IDbConnection, TResult> transaction)
        {
            var cnn = Cnn;
            IDbTransaction tran = null;
            try
            {
                cnn.Open();
                tran = cnn.BeginTransaction();
                var result = transaction(cnn);

                if (transaction.Method.IsDefined(typeof(AsyncStateMachineAttribute), false))
                    (result as Task)?.Wait();

                tran.Commit();
                return result;
            }
            catch
            {
                tran?.Rollback();
                throw;
            }
            finally
            {
                cnn.Close();
                cnn.Dispose();
            }
        }
    }
}
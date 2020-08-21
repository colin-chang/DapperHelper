using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dapper
{
    public interface IDapperHelper
    {
        /// <summary>
        /// Execute a non-query command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        int Execute(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a non-query command asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        object QueryScalar(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute parameterized SQL asynchronously that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        Task<object> QueryScalarAsync(string sql, object param = null,
            CommandType? commandType = null);


        /// <summary>
        /// Execute a query.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        IEnumerable<T> Query<T>(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a query asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null,
            CommandType? commandType = null);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        IEnumerable<TReturn> Query<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(string sql,
            Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="T3">The third type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        IEnumerable<TReturn> Query<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="T3">The third type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(string sql,
            Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null,
            bool buffered = true);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets</returns>
        IEnumerable<IEnumerable<object>> QueryMultiple(IEnumerable<string> sqls, object param = null,
            CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets</returns>
        Task<IEnumerable<IEnumerable<object>>> QueryMultipleAsync(IEnumerable<string> sqls,
            object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2) QueryMultiple<T1, T2>(
            IEnumerable<string> sqls, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2)>
            QueryMultipleAsync<T1, T2>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3)
            QueryMultiple<T1, T2, T3>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3)>
            QueryMultipleAsync<T1, T2, T3>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4)
            QueryMultiple<T1, T2, T3, T4>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4)>
            QueryMultipleAsync<T1, T2, T3, T4>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5)
            QueryMultiple<T1, T2, T3, T4, T5>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5)>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6)
            QueryMultiple<T1, T2, T3, T4, T5, T6>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <typeparam name="T9">The type of the ninth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8, IEnumerable<T9> Result9)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <typeparam name="T9">The type of the ninth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8, IEnumerable<T9> Result9)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam>
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <typeparam name="T9">The type of the ninth sql record set.</typeparam>
        /// <typeparam name="T10">The type of the tenth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        (IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
            IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
            IEnumerable<T8> Result8, IEnumerable<T9> Result9, IEnumerable<T10> Result10)
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(IEnumerable<string> sqls,
                object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a command with multiple result sets and get its reader.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets reader</returns>
        SqlMapper.GridReader QueryMultipleReader(IEnumerable<string> sqls,
            object param = null,
            CommandType? commandType = null);


        /// <summary>
        /// Execute a command with multiple result sets and get its reader.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>Multiple result sets reader</returns>
        Task<SqlMapper.GridReader> QueryMultipleReaderAsync(IEnumerable<string> sqls,
            object param = null,
            CommandType? commandType = null);

        /// <summary>
        /// Execute a command that returns multiple result sets, and access each in turn.
        /// </summary>
        /// <param name="sqls">The SQL to execute for this query.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <typeparam name="T1">The type of the first sql record set.</typeparam>
        /// <typeparam name="T2">The type of the second sql record set.</typeparam>
        /// <typeparam name="T3">The type of the third sql record set.</typeparam>
        /// <typeparam name="T4">The type of the fourth sql record set.</typeparam>
        /// <typeparam name="T5">The type of the fifth sql record set.</typeparam> 
        /// <typeparam name="T6">The type of the sixth sql record set.</typeparam>
        /// <typeparam name="T7">The type of the seventh sql record set.</typeparam>
        /// <typeparam name="T8">The type of the eighth sql record set.</typeparam>
        /// <typeparam name="T9">The type of the ninth sql record set.</typeparam>
        /// <typeparam name="T10">The type of the tenth sql record set.</typeparam>
        /// <returns>Multiple result sets</returns>
        Task<(IEnumerable<T1> Result1, IEnumerable<T2> Result2, IEnumerable<T3> Result3,
                IEnumerable<T4> Result4, IEnumerable<T5> Result5, IEnumerable<T6> Result6, IEnumerable<T7> Result7,
                IEnumerable<T8> Result8, IEnumerable<T9> Result9, IEnumerable<T10> Result10)>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                IEnumerable<string> sqls, object param = null,
                CommandType? commandType = null);


        /// <summary>
        /// Execute a non-query transaction.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        int ExecuteTransaction(IEnumerable<SqlScript> scripts);

        /// <summary>
        /// Execute a non-query transaction asynchronously.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteTransactionAsync(IEnumerable<SqlScript> scripts);

        /// <summary>
        /// Execute a transaction with the specify operation inside
        /// </summary>
        /// <param name="transaction">transaction operation</param>
        void ExecuteTransaction(Action<IDbConnection> transaction);

        /// <summary>
        /// Execute a transaction with the specify operation inside
        /// </summary>
        /// <param name="transaction">transaction operation</param>
        /// <typeparam name="TResult">return value type of the transaction operation</typeparam>
        /// <returns>return value of the transaction operation</returns>
        TResult ExecuteTransaction<TResult>(Func<IDbConnection, TResult> transaction);
    }
}
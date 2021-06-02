﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace EntityDapperCore.DataAccessLayer
{
    public interface ISqlContext : IAsyncDisposable
    {
        Task<IEnumerable<T>> GetDataAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
            where T : class;

        Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThrid : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThrid : class
            where TFourth : class
            where TReturn : class;

        Task<T> GetObjectAsync<T>(string query, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
            where T : class;

        Task<TReturn> GetObjectAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        Task<T> GetSingleValueAsync<T>(string query, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);

        Task ExecuteAsync(string query, object param = null, IDbTransaction transaction = null, CommandType? commandType = null);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EntityDapperCore.DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityDapperCore.DataAccessLayer
{
    public class DataContext : DbContext, IDbContext, ISqlContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        private IDbConnection connection;
        private IDbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(Database.GetDbConnection().ConnectionString);
                }

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return connection;
            }
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class
        {
            var set = Set<T>();
            return trackingChanges ? set.AsTracking() : set.AsNoTracking();
        }

        public void Insert<T>(T entity) where T : class => Set<T>().Add(entity);

        public void Delete<T>(T entity) where T : class => Set<T>().Remove(entity);

        public Task SaveAsync()
            => SaveChangesAsync();

        public Task<IEnumerable<T>> GetDataAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
            where T : class
            => Connection.QueryAsync<T>(sql, param, transaction, commandType: commandType);

        public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TReturn : class
            => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

        public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThrid : class
            where TReturn : class
            => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

        public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThrid : class
            where TFourth : class
            where TReturn : class
            => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

        public Task<T> GetObjectAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
            where T : class
            => Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandType: commandType);

        public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TReturn : class
        {
            var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class
        {
            var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class
        {
            var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public Task<T> GetSingleValueAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
            => Connection.ExecuteScalarAsync<T>(sql, param, transaction, commandType: commandType);

        public Task ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
           => Connection.ExecuteAsync(sql, param, transaction, commandType: commandType);

        public override ValueTask DisposeAsync()
        {
            if (connection?.State == ConnectionState.Open)
            {
                connection.Close();
            }

            connection?.Dispose();
            connection = null;

            return base.DisposeAsync();
        }
    }
}

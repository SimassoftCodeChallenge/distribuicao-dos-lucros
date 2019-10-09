using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;

namespace Simasoft.Challenge.Lucro.Infra.DapperExtensionsCore
{
    public interface IDatabaseAsync: IDisposable {

        bool HasActiveTransaction { get; }
        IDbConnection Connection { get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
        void RunInTransaction(Action action);
        T RunInTransaction<T>(Func<T> func);

        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Get{T}"/>.
        /// </summary>
        Task<T> GetAsync<T>(IDbConnection connection, dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.GetList{T}"/>.
        /// </summary>
        Task<IEnumerable<T>> GetListAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.GetList{T}(object,IDbTransaction,int?)"/>.
        /// </summary>
        Task<IEnumerable<T>> GetListAsync<T>(object predicate = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;        
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.GetPage{T}"/>.
        /// </summary>
        Task<IEnumerable<T>> GetPageAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, int page = 1, int resultsPerPage = 10, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.GetSet{T}"/>.
        /// </summary>
        Task<IEnumerable<T>> GetSetAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, int firstResult = 1, int maxResults = 10, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Count{T}"/>.
        /// </summary>
        Task<int> CountAsync<T>(IDbConnection connection, object predicate = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class;

        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Insert{T}(IDbConnection, IEnumerable{T}, IDbTransaction, int?)"/>.
        /// </summary>
        Task InsertAsync<T>(IDbConnection connection, IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : class;

        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Insert{T}(T , int?)"/>.
        /// </summary>
        Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Insert{T}(IDbConnection, T, IDbTransaction, int?)"/>.
        /// </summary>
        Task<dynamic> InsertAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = default(int?)) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Update{T}(IDbConnection, T, IDbTransaction, int?)"/>.
        /// </summary>
        Task<bool> UpdateAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction, int? commandTimeout, bool ignoreAllKeyProperties = false) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Update{T}(T, int?, bool)"/>.
        /// </summary>
        Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Delete{T}(IDbConnection, T, IDbTransaction, int?)"/>.
        /// </summary>
        Task<bool> DeleteAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction, int? commandTimeout) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Delete{T}(IDbConnection, object, IDbTransaction, int?)"/>.
        /// </summary>
        Task<bool> DeleteAsync<T>(IDbConnection connection, object predicate, IDbTransaction transaction, int? commandTimeout) where T : class;
        /// <summary>
        /// The asynchronous counterpart to <see cref="IDapperImplementor.Delete{T}(object, IDbTransaction, int?)"/>.
        /// </summary>
        Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class;
        void ClearCache();
        Task<Guid> GetNextGuid();
        IClassMapper GetMap<T>() where T : class;
    }

    public class DatabaseAsync : IDatabaseAsync
    {
        private readonly IDapperAsyncImplementor _dapper;

        private IDbTransaction _transaction;

        public DatabaseAsync(IDbConnection connection, ISqlGenerator sqlGenerator)
        {
            _dapper = new DapperAsyncImplementor(sqlGenerator);
            Connection = connection;
            
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }

        public bool HasActiveTransaction => _transaction != null;

        public IDbConnection Connection {get; private set;}

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = Connection.BeginTransaction(isolationLevel);
        }

        public void ClearCache()
        {
            _dapper.SqlGenerator.Configuration.ClearCache();
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public async Task<int> CountAsync<T>(IDbConnection connection, object predicate = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.CountAsync<T>(Connection, predicate, transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return await _dapper.DeleteAsync<T>(connection,entity,transaction, commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(IDbConnection connection, object predicate, IDbTransaction transaction, int? commandTimeout) where T : class
        {
            return await _dapper.DeleteAsync<T>(connection,predicate,transaction,commandTimeout);
        }

        public async Task<bool> DeleteAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await _dapper.DeleteAsync(Connection, entity,_transaction, commandTimeout);
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }

                Connection.Close();
            }
        }

        public async Task<T> GetAsync<T>(IDbConnection connection, dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetAsync<T>(connection,id,transaction,commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(connection,predicate,sort,transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(object predicate = null, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetListAsync<T>(Connection,predicate,null,transaction,commandTimeout);
        }

        public IClassMapper GetMap<T>() where T : class
        {
            return _dapper.SqlGenerator.Configuration.GetMap<T>();
        }

        public async Task<Guid> GetNextGuid()
        {
            return await Task.FromResult(_dapper.SqlGenerator.Configuration.GetNextGuid());
        }

        public async Task<IEnumerable<T>> GetPageAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, int page = 1, int resultsPerPage = 10, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetPageAsync<T>(connection, predicate,sort,page,resultsPerPage,transaction,commandTimeout);
        }

        public async Task<IEnumerable<T>> GetSetAsync<T>(IDbConnection connection, object predicate = null, IList<ISort> sort = null, int firstResult = 1, int maxResults = 10, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.GetSetAsync<T>(connection,predicate,sort,firstResult,maxResults,transaction,commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(T entity, int? commandTimeout = null) where T : class
        {
            return await _dapper.InsertAsync(Connection,entity,_transaction,commandTimeout);
        }

        public async Task InsertAsync<T>(IDbConnection connection, IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            await _dapper.InsertAsync<T>(connection,entities,transaction,commandTimeout);
        }

        public async Task<dynamic> InsertAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return await _dapper.InsertAsync<T>(connection,entity,transaction,commandTimeout);
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        public void RunInTransaction(Action action)
        {
            BeginTransaction();
            try
            {
                action();
                Commit();
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public T RunInTransaction<T>(Func<T> func)
        {
            BeginTransaction();
            try
            {
                T result = func();
                Commit();
                return result;
            }
            catch (Exception ex)
            {
                if (HasActiveTransaction)
                {
                    Rollback();
                }

                throw ex;
            }
        }

        public Task<bool> UpdateAsync<T>(IDbConnection connection, T entity, IDbTransaction transaction, int? commandTimeout, bool ignoreAllKeyProperties = false) where T : class
        {
            return _dapper.UpdateAsync<T>(connection,entity,transaction,commandTimeout);
        }

        public Task<bool> UpdateAsync<T>(T entity, int? commandTimeout = null, bool ignoreAllKeyProperties = false) where T : class
        {
            return _dapper.UpdateAsync(Connection,entity,_transaction,commandTimeout,ignoreAllKeyProperties);
        }
    }
}
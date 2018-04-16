using Lokesh.Infrastructure.DbFactory;
using Lokesh.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lokesh.Repository.UnitOfWork
{
    public class DPUnitOfWork : IDPUnitOfWork
    {
        private IDbFactory _factory;
        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private bool _disposed;

        public DPUnitOfWork(IDbFactory factory)
        {
            _factory = factory;
            _connection = _factory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection Connection { get => _connection; }

        public IDbTransaction Transaction { get => _transaction; }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            _transaction = _connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                //resetRepositories();
            }
        }

        public void CommitAndRefreshChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RollbackChanges()
        {
            try
            {
                _transaction.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
                //resetRepositories();
            }
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DPUnitOfWork()
        {
            dispose(false);
        }
    }
}

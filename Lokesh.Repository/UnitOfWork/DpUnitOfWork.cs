using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lokesh.Repository.UnitOfWork
{
    public class DPUnitOfWork : IDPUnitOfWork
    {
        public IDbConnection DbContext => throw new NotImplementedException();

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void RollbackChanges()
        {
            throw new NotImplementedException();
        }
    }
}

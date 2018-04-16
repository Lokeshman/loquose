using Dapper;
using Lokesh.Infrastructure.Entity;
using Lokesh.Infrastructure.Repository;
using Lokesh.Repository.Extensions;
using Lokesh.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lokesh.Repository
{
    public class Repository<T> : RepositoryBase<T> where T : EntityBase, IAggregateRoot
    {
        private readonly string _tableName;

        protected IDbTransaction Transaction { get; set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }


        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public Repository(IDPUnitOfWork uow) : base(uow)
        {
            Transaction = uow.Transaction;
            var item = Activator.CreateInstance<T>();
            _tableName = item._tableName;
        }

        public override IQueryable<T> Collection => throw new NotImplementedException();

        public override void Add(T item)
        {
            var parameters = (object)Mapping(item);
            var itemId = Connection.Insert<object>(_tableName, parameters, transaction: Transaction);
        }

        public override bool Exists(T item)
        {
            throw new NotImplementedException();
        }

        public override T Find(Func<T, bool> acquire)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> FindAll()
        {
            return Connection.Query<T>(string.Format("SELECT * FROM {0}", _tableName), transaction: Transaction);
        }

        public override T Get(object key)
        {
            throw new NotImplementedException();
        }

        public override void Merge(T persisted, T current)
        {
            throw new NotImplementedException();
        }

        public override void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public override void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

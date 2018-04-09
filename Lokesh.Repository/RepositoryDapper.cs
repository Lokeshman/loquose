using Lokesh.Infrastructure.Entity;
using Lokesh.Infrastructure.Repository;
using Lokesh.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Linq.Expressions;
using Lokesh.Repository.Initializer;

namespace Lokesh.Repository
{
    public abstract class RepositoryDapper<T> : RepositoryBase<T> where T : EntityBase, IAggregateRoot
    {
        private readonly string _tableName;

        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection
        {
            get
            {
                //return new SqlConnection(ConfigurationManager.ConnectionStrings["SmsQuizConnection"].ConnectionString);                
                return Transaction.Connection;
            }
        }


        public RepositoryDapper(string tableName, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _tableName = tableName;
        }

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public override void Add(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                item.Id = cn.Insert<Guid>(_tableName, parameters);
            }
        }

        public virtual void Update(T item)
        {
            using (IDbConnection cn = Connection)
            {
                var parameters = (object)Mapping(item);
                cn.Open();
                cn.Update(_tableName, parameters);
            }
        }

        public override void Remove(T item)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Execute("DELETE FROM " + _tableName + " WHERE Id=@Id", new { Id = item.Id });
            }
        }

        public virtual T FindByID(Guid id)
        {
            T item = default(T);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
            }

            return item;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> items = null;

            // extract the dynamic sql query and parameters from predicate
            QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>(result.Sql, (object)result.Param);
            }

            return items;
        }

        public override IEnumerable<T> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM " + _tableName);
            }

            return items;
        }

    }

    public static class DapperExtensions
    {
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.First();
        }

        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }
    }
}

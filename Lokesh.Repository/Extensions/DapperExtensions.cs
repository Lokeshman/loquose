namespace Lokesh.Repository.Extensions
{
    using Dapper;
    using Lokesh.Repository.Initializer;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;


    public static class DapperExtensions
    {
        public static T Insert<T>(this IDbConnection cnn, string tableName, dynamic param, IDbTransaction transaction)
        {
            IEnumerable<T> result = SqlMapper.Query<T>(cnn, DynamicQuery.GetInsertQuery(tableName, param), param, transaction);
            return result.First();
        }

        public static void Update(this IDbConnection cnn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cnn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }
    }
}

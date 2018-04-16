using Lokesh.Infrastructure.DbFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Lokesh.Repository.DbFactories
{
    public class SqlDbFactory : IDbFactory
    {
        private readonly IDappererSettings _dappererSettings;
        private readonly IDbConnection _connection;

        public SqlDbFactory(IDappererSettings dappererSettings)
        {
            _dappererSettings = dappererSettings;
            _connection = new SqlConnection(_dappererSettings.ConnectionString);
        }

        public SqlDbFactory(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection CreateConnection()
        {
            //return new SqlConnection(_dappererSettings.ConnectionString);
            return _connection;
        }
    }

    public class DefaultDappererSettings : IDappererSettings
    {
        public string ConnectionString
        {
            get
            {
                var connectionString = @"Server=LOINGUYEN-SMOOV;Database=Equinox;Trusted_Connection=true;";
                return connectionString;
                //return ConfigurationManager.AppSettings.Get("Dapperer.ConnectionString");
            }
        }
    }
}

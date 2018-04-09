using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lokesh.Repository.Initializer
{
    public class DpContext : IDisposable
    {
        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection
        {
            get
            {
                //return new SqlConnection(ConfigurationManager.ConnectionStrings["SmsQuizConnection"].ConnectionString);                
                return Transaction.Connection;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

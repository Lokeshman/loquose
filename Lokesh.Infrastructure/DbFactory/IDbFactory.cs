using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lokesh.Infrastructure.DbFactory
{
    public interface IDbFactory
    {
        IDbConnection CreateConnection();
    }
}

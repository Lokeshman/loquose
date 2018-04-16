using System;
using System.Collections.Generic;
using System.Text;

namespace Lokesh.Infrastructure.DbFactory
{
    public interface IDappererSettings
    {
        string ConnectionString { get; }
    }
}

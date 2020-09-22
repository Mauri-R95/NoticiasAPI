using System;
using System.Collections.Generic;
using System.Text;

namespace Noticias.Infrastructure
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; }
    }
}

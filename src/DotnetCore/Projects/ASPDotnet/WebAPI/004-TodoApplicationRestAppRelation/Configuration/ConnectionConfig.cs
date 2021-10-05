using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.TodoApplicationRestApp.Configuration
{
    public class ConnectionConfig
    {
        public string ConnectionString { get; } = @"Server=.;Database=TodoDb;Trusted_Connection=True;";
    }
}

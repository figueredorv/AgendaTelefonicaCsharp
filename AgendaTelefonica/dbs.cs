using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica
{
    class dbs
    {
        private String connectionString;

        public String getConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AgendaTelefonica.Properties.Settings.crudConnectionString"].ConnectionString;
            return connectionString;
        }
    }
}

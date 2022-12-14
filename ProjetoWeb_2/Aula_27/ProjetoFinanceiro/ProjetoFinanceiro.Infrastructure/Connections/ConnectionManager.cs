using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Connections
{
    public class ConnectionManager
    {
        private static string ConnStr = "";
        private static SqlConnection connection = null;

        public ConnectionManager(string connectionString)
        {
            ConnStr = connectionString;
        }

        public SqlConnection GetConnection()
        {
            if(connection == null)
            {
                connection = new SqlConnection(ConnStr);
            }

            return connection;
        }
    }
}

using Microsoft.Extensions.Configuration;
using ProjetoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoFinanceiro.Testes.Contexts
{
    public class ConnectionTest
    {
        private readonly ConnectionManager _connectionManager;
        private readonly IConfiguration _configuration;

        public ConnectionTest(IConfiguration configuration)
        {
            _configuration = configuration;
            string connStr = _configuration["ApiConfig:ConnectionStrings:projfinancdb"];
            _connectionManager = new ConnectionManager(connStr);
        }

        public void Execute()
        {
            ValidarConectividadeBancoDados();
        }

        private void ValidarConectividadeBancoDados()
        {
            SqlConnection connection = null;

            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}

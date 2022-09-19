using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Infrastructure.Connections;
using ProjetoFinanceiro.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class SqlServerContext : IContext
    {
        private readonly IApiConfig _apiConfig;

        private static string _connectionString = "";
        private readonly ConnectionManager _connectionManager;

        public SqlServerContext(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
            _connectionString = _apiConfig.ConnectionStrings.projfinancdb;
            _connectionManager = new ConnectionManager(_connectionString);
        }

        public void CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public int NextId()
        {
            return 0;
        }

        public List<Cliente> ReadCliente()
        {
            List<Cliente> result = new List<Cliente>();
            SqlConnection cn = null;

            try
            {
                cn = _connectionManager.GetConnection();
                string sql = SqlManager.GetSql(SqlQueryType.LISTAR_CLIENTE);

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "consultaCliente");

                foreach (DataRow registro in ds.Tables["consultaCliente"].Rows)
                {
                    Cliente cliente = new Cliente
                    {
                        ClienteId = Int32.Parse(registro["cod_cli"].ToString()),
                        Nome = registro["nome_cli"].ToString(),
                        Cpf = registro["cpf_cli"].ToString()
                    };

                    result.Add(cliente);
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();
            }
        }

        public Cliente ReadCliente(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}

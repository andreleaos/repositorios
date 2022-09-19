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
            SqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.CADASTRAR_CLIENTE);
                cn = _connectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@nome_cli", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@cpf_cli", SqlDbType.VarChar).Value = cliente.Cpf;
                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();

                cn = null;
            }
        }

        public void DeleteCliente(int id)
        {
            SqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.EXCLUIR_CLIENTE);
                cn = _connectionManager.GetConnection();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = id;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();

                cn = null;
            }
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
                cn = null;
            }
        }

        public Cliente ReadCliente(int id)
        {
            Cliente result = null;

            SqlConnection cn = null;

            try
            {
                cn = _connectionManager.GetConnection();
                string sql = SqlManager.GetSql(SqlQueryType.PESQUISAR_CLIENTE);

                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "pesquisaCliente");

                DataRowCollection registros = ds.Tables["pesquisaCliente"].Rows;

                foreach (DataRow item in registros)
                {
                    result = new Cliente
                    {
                        ClienteId = Int32.Parse(item["cod_cli"].ToString()),
                        Nome = item["nome_cli"].ToString(),
                        Cpf = item["cpf_cli"].ToString()
                    };
                }

                ds.Clear();
                ds = null;
                cmd = null;

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn = null;
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            SqlConnection cn = null;

            try
            {
                string sql = SqlManager.GetSql(SqlQueryType.ATUALIZAR_CLIENTE);
                cn = _connectionManager.GetConnection();

                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.Add("@nome_cli", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@cpf_cli", SqlDbType.VarChar).Value = cliente.Cpf;
                cmd.Parameters.Add("@cod_cli", SqlDbType.Int).Value = cliente.ClienteId;

                cn.Open();
                cmd.ExecuteNonQuery();

                cmd = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State.Equals(ConnectionState.Open))
                    cn.Close();

                cn = null;
            }
        }
    }
}

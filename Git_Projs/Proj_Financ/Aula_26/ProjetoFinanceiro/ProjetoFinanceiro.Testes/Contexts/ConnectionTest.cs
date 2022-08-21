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
            //ValidarConectividadeBancoDados();
            ValidarConsultaSimples();
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

        private void ValidarConsultaSimples()
        {
            SqlConnection connection = null;

            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();

                string sql_select = "select cod_cli, nome_cli, cpf_cli from tb_cliente";

                SqlCommand cmd = new SqlCommand(sql_select, connection);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string nome1 = dr[1].ToString();
                        string nome2 = dr.GetString("nome_cli");

                        string cpf = dr["cpf_cli"].ToString();

                        int id = dr.GetInt32("cod_cli");
                        int id2 = Int32.Parse(dr["cod_cli"].ToString());
                    }
                }

                cmd = null;
                dr.Close();
                dr = null;

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

        private void ValidarConsultaSimples2()
        {
            SqlConnection connection = null;

            try
            {
                connection = _connectionManager.GetConnection();
                connection.Open();

                string sql_select = "select cod_cli, nome_cli, cpf_cli from tb_cliente";

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql_select, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "consulta");

                foreach (DataRow linha in ds.Tables["consulta"].Rows)
                {
                    string nome = linha["nome_cli"].ToString();
                    string cpf = linha["cpf_cli"].ToString();
                }

                ds = null;
                da = null;
                cmd = null;

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

using ProjetoFinanceiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class SqlManager
    {
        public static string GetSql(SqlQueryType queryType)
        {
            string sql = "";

            switch (queryType)
            {
                case SqlQueryType.LISTAR_CLIENTE:
                    sql = "select cod_cli, nome_cli, cpf_cli from tb_cliente";
                    break;

                case SqlQueryType.PESQUISAR_CLIENTE:
                    sql = "select cod_cli, nome_cli, cpf_cli from tb_cliente where cod_cli = @cod_cli";
                    break;

                case SqlQueryType.CADASTRAR_CLIENTE:
                    sql = "insert into tb_cliente (nome_cli, cpf_cli) values (@nome_cli, @cpf_cli)";
                    break;

                case SqlQueryType.ATUALIZAR_CLIENTE:
                    sql = "update tb_cliente set nome_cli = @nome_cli, cpf_cli = @cpf_cli where cod_cli = @cod_cli";
                    break;

                case SqlQueryType.EXCLUIR_CLIENTE:
                    sql = "delete from tb_cliente where cod_cli = @cod_cli";
                    break;
            }

            return sql;
        }

    }
}

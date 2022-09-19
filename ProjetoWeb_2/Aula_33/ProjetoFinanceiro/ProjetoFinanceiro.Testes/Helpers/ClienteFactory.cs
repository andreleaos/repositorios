using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteFactory
    {
        public static Cliente GetCliente()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            return cliente;
        }

        public static Cliente GetNovoCliente()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 12,
                Nome = "Roberto Maravilha",
                Cpf = "65989726421"
            };

            return cliente;
        }
    }
}

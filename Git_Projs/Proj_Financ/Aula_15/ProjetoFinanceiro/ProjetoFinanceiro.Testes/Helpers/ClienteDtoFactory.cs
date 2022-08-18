using ProjetoFinanceiro.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes.Helpers
{
    public static class ClienteDtoFactory
    {
        public static ClienteDto GetClienteDto()
        {
            ClienteDto cliente = new ClienteDto
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            return cliente;
        }
    }
}

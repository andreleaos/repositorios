using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class DominioTeste
    {
        public void Execute()
        {
            TestarEntidade();
            TestarDto();
            TestarConversaoEntidadeParaDto();
            TestarConversaoDtoParaEntidade();
        }

        private void TestarEntidade()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }
        private void TestarDto()
        {
            ClienteDto cliente = new ClienteDto
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            string message = $"Id: {cliente.ClienteId}, Nome: {cliente.Nome}";
            Console.WriteLine(message);
        }
        private void TestarConversaoEntidadeParaDto()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            ClienteDto dto = cliente.ConverterParaDto();

            string message = $"Id: {dto.ClienteId}, Nome: {dto.Nome}";
            Console.WriteLine(message);
        }
        private void TestarConversaoDtoParaEntidade()
        {
            ClienteDto cliente = new ClienteDto
            {
                ClienteId = 1,
                Nome = "Joao de Souza",
                Cpf = "12345678901"
            };

            Cliente entidade = cliente.ConverterParaEntidade();

            string message = $"Id: {entidade.ClienteId}, Nome: {entidade.Nome}";
            Console.WriteLine(message);
        }

    }
}

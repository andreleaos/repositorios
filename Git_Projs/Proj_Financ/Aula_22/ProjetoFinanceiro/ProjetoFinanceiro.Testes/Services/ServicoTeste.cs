using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Services.Service;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes.Services
{
    public class ServicoTeste
    {
        private readonly ClienteService _clienteService;

        public ServicoTeste(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void Execute()
        {
            try
            {
                ValidarListagemClientes();
                ValidarPesquisaCliente();
                ValidarCadastroCliente();
                ValidarAtualizacaoCliente();
                ValidarExclusaoCliente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarListagemClientes()
        {
            Console.WriteLine("\nTeste Camada de Serviço: ValidarListagemClientes");
            List<Cliente> clientes = _clienteService.Listar();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            Console.WriteLine("\nTeste Camada de Serviço: ValidarPesquisaCliente");
            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            Console.WriteLine("\nTeste Camada de Serviço: ValidarCadastroCliente");

            Cliente cliente = ClienteFactory.GetNovoCliente();
            int id = cliente.ClienteId;

            _clienteService.Salvar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id:{objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarAtualizacaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Serviço: ValidarAtualizacaoCliente");

            int id = 1;
            Cliente cliente = _clienteService.Pesquisar(id);
            cliente.Nome = "Oliver Tsubasa";
            _clienteService.Atualizar(cliente);

            Cliente objPesquisa = _clienteService.Pesquisar(id);
            Console.WriteLine($"Id:{objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            Console.WriteLine("\nTeste Camada de Serviço: ValidarExclusaoCliente");

            int id = 12;
            _clienteService.Excluir(id);

            Cliente cliente = _clienteService.Pesquisar(id);
        }
    }
}

using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Repositories;
using ProjetoFinanceiro.Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes.Repositories
{
    public class RepositorioTeste
    {
        private readonly IClienteRepository _clienteRepository;

        public RepositorioTeste(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
            List<Cliente> clientes = _clienteRepository.Listar();
            foreach(Cliente cliente in clientes)
            {
                Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
            }
        }

        private void ValidarPesquisaCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id:{cliente.ClienteId}, Nome:{cliente.Nome}");
        }

        private void ValidarCadastroCliente()
        {
            Cliente cliente = ClienteFactory.GetNovoCliente();
            int id = cliente.ClienteId;

            _clienteRepository.Salvar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id:{objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }
 
        private void ValidarAtualizacaoCliente()
        {
            int id = 1;
            Cliente cliente = _clienteRepository.Pesquisar(id);
            cliente.Nome = "Oliver Tsubasa";
            _clienteRepository.Atualizar(cliente);

            Cliente objPesquisa = _clienteRepository.Pesquisar(id);
            Console.WriteLine($"Id:{objPesquisa.ClienteId}, Nome:{objPesquisa.Nome}");
        }

        private void ValidarExclusaoCliente()
        {
            int id = 12;
            _clienteRepository.Excluir(id);

            Cliente cliente = _clienteRepository.Pesquisar(id);
        }
    }
}

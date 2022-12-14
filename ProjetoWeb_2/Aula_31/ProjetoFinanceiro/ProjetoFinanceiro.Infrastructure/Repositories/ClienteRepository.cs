using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Domain.Setup;
using ProjetoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IContext _context;
        private readonly IApiConfig _apiConfig;

        public ClienteRepository(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;

            switch (ConfiguracoesApp.SELECTED_DATABASE)
            {
                case DatabaseType.Fake:
                    _context = new FakeContext();
                    break;

                case DatabaseType.SqlServer:
                    _context = new SqlServerContext(_apiConfig);
                    break;

                case DatabaseType.MySql:
                    _context = new MySqlContext(_apiConfig);
                    break;
            }

        }

        public void Atualizar(Cliente cliente)
        {
            _context.UpdateCliente(cliente);
        }

        public void Excluir(int id)
        {
            _context.DeleteCliente(id);
        }

        public List<Cliente> Listar()
        {
            return _context.ReadCliente();
        }

        public Cliente Pesquisar(int id)
        {
            return _context.ReadCliente(id);
        }

        public void Salvar(Cliente cliente)
        {
            if (ConfiguracoesApp.SELECTED_DATABASE.Equals(DatabaseType.Fake))
            {
                cliente.ClienteId = _context.NextId();
            }

            _context.CreateCliente(cliente);
        }
    }
}

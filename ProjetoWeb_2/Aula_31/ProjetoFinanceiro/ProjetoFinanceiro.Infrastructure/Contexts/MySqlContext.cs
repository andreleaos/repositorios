using ProjetoFinanceiro.Domain.Configuration;
using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class MySqlContext : IContext
    {
        private readonly IApiConfig _apiConfig;

        public MySqlContext(IApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
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
            throw new NotImplementedException();
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

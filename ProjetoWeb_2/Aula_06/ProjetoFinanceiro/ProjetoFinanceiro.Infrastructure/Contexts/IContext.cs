using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public interface IContext
    {
        public void CreateCliente(Cliente cliente);
        public List<Cliente> ReadCliente();
        public Cliente ReadCliente(int id);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);
    }
}

using ProjetoFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinanceiro.Infrastructure.Contexts
{
    public class FakeContext : IContext
    {
        private List<Cliente> _clientes;

        public FakeContext()
        {
            LoadData();
        }

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public List<Cliente> ReadCliente()
        {
            return _clientes
                .OrderBy(p => p.ClienteId)
                .ToList();
        }

        public Cliente ReadCliente(int id)
        {
            Cliente result = _clientes
                .FirstOrDefault(p => p.ClienteId.Equals(id));
            
            return result;
        }

        public void UpdateCliente(Cliente cliente)
        {
            Cliente objPesquisa = ReadCliente(cliente.ClienteId);
            _clientes.Remove(objPesquisa);

            objPesquisa = new Cliente
            {
                ClienteId = cliente.ClienteId,
                Nome = !string.IsNullOrEmpty(cliente.Nome) ? cliente.Nome : objPesquisa.Nome,
                Cpf = !string.IsNullOrEmpty(cliente.Cpf) ? cliente.Cpf : objPesquisa.Cpf
            };
            _clientes.Add(objPesquisa);
        }

        public void DeleteCliente(int id)
        {
            Cliente cliente = ReadCliente(id);
            if (cliente != null)
                _clientes.Remove(cliente);
        }


        private void LoadData()
        {
            _clientes = new List<Cliente>();

            Cliente cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Flavio Ferreira",
                Cpf = "32145695483"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 2,
                Nome = "Jose dos Santos",
                Cpf = "65478932165"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 3,
                Nome = "Antonio Alvez",
                Cpf = "332451789658"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 4,
                Nome = "Xerox Fotocopia Silva",
                Cpf = "65478932169"
            };
            _clientes.Add(cliente);

            cliente = new Cliente
            {
                ClienteId = 5,
                Nome = "Maikon Jackson Rocha",
                Cpf = "69845732542"
            };
            _clientes.Add(cliente);
        }

        public int NextId()
        {
            int id = _clientes.Max(p => p.ClienteId);
            id++;
            return id;
        }
    }
}

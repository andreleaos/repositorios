using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class FakeContextTeste
    {
        private readonly IContext _context;

        public FakeContextTeste()
        {
            _context = new FakeContext();
        }

        public void Execute()
        {
            TestarListagem();
            TestarInclusao();
        }

        private void TestarListagem()
        {
            List<Cliente> clientes = _context.ReadCliente();
            foreach(Cliente item in clientes)
            {
                Console.WriteLine($"Id:{item.ClienteId}, Nome:{item.Nome}");
            }
        }
        private void TestarInclusao()
        {
            Cliente cliente = new Cliente
            {
                ClienteId = 12,
                Nome = "Roberto Maravilha",
                Cpf = "65989726421"
            };

            _context.CreateCliente(cliente);

            Cliente result = _context.ReadCliente(cliente.ClienteId);
        }
    }
}

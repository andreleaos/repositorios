using EstudosEFCore.Models.Domain.Entities;
using EstudosEFCore.Models.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Infrastructure.Repositories
{
    public class VeiculoRepositoryImpl : VeiculoRepository
    {
        private readonly ControleFrotaContext _context;

        public VeiculoRepositoryImpl(ControleFrotaContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(string veiculoId)
        {
            Veiculo veiculo = await Pesquisar(veiculoId);
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> Listar()
        {
            List<Veiculo> veiculos = await _context.Veiculos.ToListAsync();
            return veiculos;
        }

        public async Task<List<Veiculo>> Listar2()
        {
            List<Veiculo> veiculos = await _context.Veiculos
                .Include(c => c.Motoristas)
                .ThenInclude(cc => cc.Veiculo)
                .ToListAsync();
            
            foreach(Veiculo item in veiculos)
            {
                foreach(MotoristaVeiculo subitem in item.Motoristas)
                {
                    subitem.Motorista = _context.Motoristas
                        .FirstOrDefault(m => m.MotoristaId.Equals(subitem.MotoristaId));
                }
            }

            return veiculos;
        }

        public async Task<Veiculo> Pesquisar(string veiculoId)
        {
            Veiculo veiculo = await _context.Veiculos
                .FirstOrDefaultAsync(p => p.VeiculoId.Equals(veiculoId));

            return veiculo;
        }
    }
}

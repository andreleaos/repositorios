using EstudosEFCore.Models.Domain.Entities;
using EstudosEFCore.Models.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Services
{
    public class VeiculoServiceImpl : VeiculoService
    {
        private readonly VeiculoRepository _veiculoRepository;

        public VeiculoServiceImpl(VeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            try
            {
                await _veiculoRepository.Atualizar(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            try
            {
                await _veiculoRepository.Cadastrar(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(string veiculoId)
        {
            try
            {
                await _veiculoRepository.Excluir(veiculoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Veiculo>> Listar()
        {
            try
            {
                return await _veiculoRepository.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Veiculo>> Listar2()
        {
            try
            {
                return await _veiculoRepository.Listar2();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Veiculo> Pesquisar(string veiculoId)
        {
            try
            {
                return await _veiculoRepository.Pesquisar(veiculoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using EstudosEFCore.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Services
{
    public interface VeiculoService
    {
        Task Cadastrar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Excluir(string veiculoId);
        Task<Veiculo> Pesquisar(string veiculoId);
        Task<List<Veiculo>> Listar();
        Task<List<Veiculo>> Listar2();

    }
}

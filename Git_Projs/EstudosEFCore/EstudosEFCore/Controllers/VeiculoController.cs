using EstudosEFCore.Models.Domain.Dtos;
using EstudosEFCore.Models.Domain.Entities;
using EstudosEFCore.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<List<Veiculo>> Get()
        {
            try
            {
                List<Veiculo> result = await _veiculoService.Listar();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<List<Veiculo>> Get2()
        {
            try
            {
                List<Veiculo> result = await _veiculoService.Listar2();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<Veiculo> Get(string id)
        {
            try
            {
                Veiculo result = await _veiculoService.Pesquisar(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> Post([FromBody] VeiculoDto veiculo)
        {
            try
            {
                Veiculo entidade = veiculo.ConverterParaEntidade();
                await _veiculoService.Cadastrar(entidade);
                return "Cadastro efetuado com sucesso!";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody] VeiculoDto veiculo)
        {
            try
            {
                Veiculo entidade = veiculo.ConverterParaEntidade();
                await _veiculoService.Atualizar(entidade);
                return "Atualizacao efetuada com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> Delete(string id)
        {
            try
            {
                await _veiculoService.Excluir(id);
                return "Exclusao efetuada com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

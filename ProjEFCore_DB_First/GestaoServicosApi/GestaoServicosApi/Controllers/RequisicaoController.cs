using GestaoServicosApi.Models.Dtos;
using GestaoServicosApi.Models.Entities;
using GestaoServicosApi.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoServicosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;

        public RequisicaoController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public List<Requisicao> Listar()
        {
            try
            {
                List<Requisicao> requisicoes = _requisicaoService.Read();
                return requisicoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public Requisicao Pesquisar(int id)
        {
            try
            {
                Requisicao requisicoes = _requisicaoService.GetById(id);
                return requisicoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        [HttpPost]    
        public string Cadastrar([FromBody] RequisicaoDto dto)
        {
            try
            {
                Requisicao requisicao = new Requisicao { Descricao = dto.Descricao };
                _requisicaoService.Create(requisicao);
                return "Cadastro Efetuado com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public string Excluir(int id)
        {
            try
            {
                _requisicaoService.Delete(id);
                return "Exclusão Efetuada com sucesso!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public string Atualizar([FromBody] RequisicaoDto dto)
        {
            try
            {
                Requisicao requisicao = new Requisicao { RequisicaoId = dto.RequisicaoId };
                _requisicaoService.Update(requisicao);
                return "Atualização efetuada com sucesso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

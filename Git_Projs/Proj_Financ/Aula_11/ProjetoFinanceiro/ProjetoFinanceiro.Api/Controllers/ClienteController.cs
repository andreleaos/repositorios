using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Domain.Dtos;
using ProjetoFinanceiro.Domain.Entities;
using ProjetoFinanceiro.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public List<ClienteDto> Get()
        {
            try
            {
                List<Cliente> clientes = _clienteService.Listar();
                List<ClienteDto> clientesDto = clientes !=null ? Cliente.ConverterParaDto(clientes) : null;
                return clientesDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ClienteDto Get(int id)
        {
            try
            {
                Cliente cliente = _clienteService.Pesquisar(id);
                ClienteDto dto = cliente != null ? cliente.ConverterParaDto() : null;
                return dto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public string Post([Bind("nome, cpf")] ClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = clienteDto.ConverterParaEntidade();
                _clienteService.Salvar(cliente);
                return $"Cliente {cliente.Nome} cadastrado com sucesso, Id: {cliente.ClienteId} ";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

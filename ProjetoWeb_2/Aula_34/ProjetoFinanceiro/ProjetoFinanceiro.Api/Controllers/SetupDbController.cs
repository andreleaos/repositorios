using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Domain.Enums;
using ProjetoFinanceiro.Domain.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupDbController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public string SetDatabase(int id)
        {
            if (id.Equals(0))
            {
                ConfiguracoesApp.SELECTED_DATABASE = DatabaseType.Fake;
            }
            else if (id.Equals(1))
            {
                ConfiguracoesApp.SELECTED_DATABASE = DatabaseType.SqlServer;
            }
            else
            {
                ConfiguracoesApp.SELECTED_DATABASE = DatabaseType.MySql;
            }

            return $"Banco de Dados Selecionado: {ConfiguracoesApp.SELECTED_DATABASE.ToString()}";
        }
    }
}

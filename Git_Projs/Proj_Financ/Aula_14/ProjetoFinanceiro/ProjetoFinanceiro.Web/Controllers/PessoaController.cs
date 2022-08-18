using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Web.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class PessoaController : Controller
    {
        private static List<PessoaDto> _pessoas = null;

        public PessoaController()
        {
            _pessoas = new List<PessoaDto>();

            PessoaDto pessoa1 = new PessoaDto { 
                Id = Guid.NewGuid().ToString(),
                Nome = "André Leão",
                Email = "andre.leao@gmail.com"
            };
            _pessoas.Add(pessoa1);

            PessoaDto pessoa2 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Jose Silva",
                Email = "jose.silva@gmail.com"
            };
            _pessoas.Add(pessoa2);

            PessoaDto pessoa3 = new PessoaDto
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Joao Antonio",
                Email = "joao.antonio@gmail.com"
            };
            _pessoas.Add(pessoa3);

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View(_pessoas);
        }
    }
}

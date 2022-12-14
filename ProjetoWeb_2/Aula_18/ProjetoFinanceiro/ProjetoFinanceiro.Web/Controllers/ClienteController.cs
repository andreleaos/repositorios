using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoFinanceiro.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly string ENDPOINT = "http://localhost:2287/api/cliente";
        private readonly HttpClient httpClient = null;

        public ClienteController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ENDPOINT);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<ClienteViewModel> clientes = null;

                HttpResponseMessage response = await httpClient.GetAsync(ENDPOINT);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    clientes = JsonConvert.DeserializeObject<List<ClienteViewModel>>(content);
                }
                else
                {
                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
                }

                return View(clientes);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }
    }
}

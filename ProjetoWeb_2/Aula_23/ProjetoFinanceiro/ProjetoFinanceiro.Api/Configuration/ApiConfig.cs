using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Api.Configuration
{
    public interface IApiConfig
    {
        ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ApiConfig : IApiConfig
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string projfinancdb { get; set; }
    }

}

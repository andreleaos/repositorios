using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Domain.Entities
{
    public class Motorista
    {
        public string MotoristaId { get; set; }
        public string Nome { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public bool? Ativo { get; set; }
        public List<MotoristaVeiculo> Veiculos { get; set; }

        public Motorista()
        {
            Veiculos = new List<MotoristaVeiculo>();
        }
    }
}

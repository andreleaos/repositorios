using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Domain.Entities
{
    public class MotoristaVeiculo
    {
        public string VeiculoId { get; set; }
        public string MotoristaId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Motorista Motorista { get; set; }
    }
}

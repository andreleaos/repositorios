using EstudosEFCore.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Domain.Dtos
{
    public class VeiculoDto
    {
        public string VeiculoId { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }

        public VeiculoDto()
        {

        }

        public Veiculo ConverterParaEntidade()
        {
            return new Veiculo
            {
                VeiculoId = !string.IsNullOrEmpty(this.VeiculoId) ? this.VeiculoId : BaseEntity.GenerateId(),
                Modelo = this.Modelo,
                Placa = this.Placa,
                Ano = this.Ano
            };
        }
    }
}

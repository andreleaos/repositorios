using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Entities
{
    public partial class Requisicao
    {
        public Requisicao()
        {
            OrdemTrabalho = new HashSet<OrdemTrabalho>();
        }

        public int RequisicaoId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAbertura { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
        public DateTime? DataFechamento { get; set; }
        public int? StatusId { get; set; }

        public virtual StatusRequisicao Status { get; set; }
        public virtual ICollection<OrdemTrabalho> OrdemTrabalho { get; set; }
    }
}

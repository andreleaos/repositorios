using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Entities
{
    public partial class OrdemTrabalho
    {
        public int RequisicaoId { get; set; }
        public int OrdemTrabalhoId { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? StatusOrdemTrabalhoId { get; set; }
        public int? AnalistaSuporteId { get; set; }

        public virtual AnalistaSuporte AnalistaSuporte { get; set; }
        public virtual Requisicao Requisicao { get; set; }
        public virtual StatusOrdemTrabalho StatusOrdemTrabalho { get; set; }
    }
}

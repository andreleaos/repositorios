using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Entities
{
    public partial class StatusRequisicao
    {
        public StatusRequisicao()
        {
            Requisicao = new HashSet<Requisicao>();
        }

        public int StatusId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Requisicao> Requisicao { get; set; }
    }
}

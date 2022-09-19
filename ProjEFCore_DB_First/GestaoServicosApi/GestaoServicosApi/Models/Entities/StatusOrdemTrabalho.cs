using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Entities
{
    public partial class StatusOrdemTrabalho
    {
        public StatusOrdemTrabalho()
        {
            OrdemTrabalho = new HashSet<OrdemTrabalho>();
        }

        public int StatusOrdemTrabalhoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<OrdemTrabalho> OrdemTrabalho { get; set; }
    }
}

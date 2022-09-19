using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GestaoServicosApi.Models.Entities
{
    public partial class AnalistaSuporte
    {
        public AnalistaSuporte()
        {
            OrdemTrabalho = new HashSet<OrdemTrabalho>();
        }

        public int AnalistaSuporteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Ramal { get; set; }
        public bool? AnalistaAtivo { get; set; }

        public virtual ICollection<OrdemTrabalho> OrdemTrabalho { get; set; }
    }
}

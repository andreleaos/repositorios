using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        public AppTestePrincipal()
        {

        }

        public void Execute()
        {
            ValidarCamadaDominio();
            ValidarCamadaEstrutura_Context();
        }

        private static void ValidarCamadaEstrutura_Context()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.TestarListagem();
            teste.TestarInclusao();
        }

        private static void ValidarCamadaDominio()
        {
            DominioTeste teste = new DominioTeste();
            teste.TestarEntidade();
            teste.TestarDto();
            teste.TestarConversaoEntidadeParaDto();
            teste.TestarConversaoDtoParaEntidade();
        }
    }
}

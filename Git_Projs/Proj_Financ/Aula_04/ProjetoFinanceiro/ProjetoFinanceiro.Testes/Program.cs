using System;

namespace ProjetoFinanceiro.Testes
{
    class Program
    {
        static void Main(string[] args)
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

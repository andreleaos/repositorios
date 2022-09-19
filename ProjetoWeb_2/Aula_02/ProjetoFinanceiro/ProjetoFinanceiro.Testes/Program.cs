using System;

namespace ProjetoFinanceiro.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidarCamadaDominio();
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

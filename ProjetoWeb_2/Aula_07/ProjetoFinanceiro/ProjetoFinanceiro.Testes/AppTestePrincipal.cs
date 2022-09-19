using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;

        public AppTestePrincipal(RepositorioTeste repositorioTeste)
        {
            _repositorioTeste = repositorioTeste;
        }

        public void Execute()
        {
            ValidarCamadaDominio();
            ValidarCamadaEstrutura_Context();
            ValidarCamadaRepositorio();
        }

        private void ValidarCamadaEstrutura_Context()
        {
            FakeContextTeste teste = new FakeContextTeste();
            teste.Execute();
        }

        private void ValidarCamadaDominio()
        {
            DominioTeste teste = new DominioTeste();
            teste.Execute();
        }

        private void ValidarCamadaRepositorio()
        {
            _repositorioTeste.Execute();
        }
    }
}

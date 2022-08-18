using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinanceiro.Testes
{
    public class AppTestePrincipal
    {
        private readonly RepositorioTeste _repositorioTeste;
        private readonly ServicoTeste _servicoTeste;

        public AppTestePrincipal(RepositorioTeste repositorioTeste,
                                 ServicoTeste servicoTeste)
        {
            _repositorioTeste = repositorioTeste;
            _servicoTeste = servicoTeste;
        }

        public void Execute()
        {
            ValidarCamadaDominio();
            ValidarCamadaEstrutura_Context();
            ValidarCamadaRepositorio();
            ValidarCamadaServico();
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

        private void ValidarCamadaServico()
        {
            _servicoTeste.Execute();
        }
    }
}

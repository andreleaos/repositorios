using GestaoServicosApi.Models.Contexts;
using GestaoServicosApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoServicosApi.Models.Repositories
{
    public class RequisicaoRepositoryImpl : RequisicaoRepository
    {
        private readonly GestaoServicoContext _context;

        public RequisicaoRepositoryImpl(GestaoServicoContext context)
        {
            _context = context;
        }

        public void Create(Requisicao entity)
        {
            string descStatusRequisicao = "Criada";
            StatusRequisicao statusRequisicao = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals(descStatusRequisicao));

            entity.Status = statusRequisicao;
            entity.StatusId = statusRequisicao.StatusId;
            entity.DataAbertura = DateTime.Now;
            entity.DataUltimaAtualizacao = DateTime.Now;

            _context.Requisicao.Add(entity);
            _context.SaveChanges();

            string descStatusOrdemTrabalho = "Nova";
            StatusOrdemTrabalho statusOrdemTrabalho = _context.StatusOrdemTrabalho
                .FirstOrDefault(p => p.Descricao.Equals(descStatusOrdemTrabalho));

            OrdemTrabalho ordemTrabalho = new OrdemTrabalho
            {
                RequisicaoId = entity.RequisicaoId,
                Descricao = "Ordem de Trabalho Criada",
                StatusOrdemTrabalhoId = statusOrdemTrabalho.StatusOrdemTrabalhoId,
                StatusOrdemTrabalho = statusOrdemTrabalho,
                DataAtualizacao = DateTime.Now
            };

            _context.OrdemTrabalho.Add(ordemTrabalho);
            _context.SaveChanges();

            List<AnalistaSuporte> analistas = _context.AnalistaSuporte
                .Where(p => p.AnalistaAtivo == true)
                .ToList();

            Random r = new Random();
            AnalistaSuporte analistaSelec = analistas[r.Next(0, analistas.Count - 1)];

            descStatusOrdemTrabalho = "Em Atendimento";
            statusOrdemTrabalho = _context.StatusOrdemTrabalho
                .FirstOrDefault(p => p.Descricao.Equals(descStatusOrdemTrabalho));

            ordemTrabalho.Descricao = "Analista Designado";
            ordemTrabalho.StatusOrdemTrabalhoId = statusOrdemTrabalho.StatusOrdemTrabalhoId;
            ordemTrabalho.StatusOrdemTrabalho = statusOrdemTrabalho;
            ordemTrabalho.AnalistaSuporte = analistaSelec;
            ordemTrabalho.AnalistaSuporteId = analistaSelec.AnalistaSuporteId;
            ordemTrabalho.DataAtualizacao = DateTime.Now;

            _context.OrdemTrabalho.Update(ordemTrabalho);
            _context.SaveChanges();

            descStatusRequisicao = "Designada para Analista";
            statusRequisicao = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals(descStatusRequisicao));

            entity.Status = statusRequisicao;
            entity.StatusId = statusRequisicao.StatusId;
            entity.DataUltimaAtualizacao = DateTime.Now;

            _context.Requisicao.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Requisicao requisicao = GetById(id);
            if (requisicao != null)
            {
                _context.Requisicao.Remove(requisicao);
                _context.SaveChanges();
            }
        }

        public Requisicao GetById(int id)
        {
            Requisicao requisicao = _context
                 .Requisicao
                 .Include(p => p.OrdemTrabalho)
                     .ThenInclude(c => c.AnalistaSuporte)
                 .Include(p => p.OrdemTrabalho)
                     .ThenInclude(p => p.StatusOrdemTrabalho)
                 .Include(p => p.Status)
                 .FirstOrDefault(p => p.RequisicaoId.Equals(id));

            return requisicao;
        }

        public List<Requisicao> Read()
        {
            List<Requisicao> requisicoes = _context.Requisicao
                .ToList();

            return requisicoes;
        }

        public void Update(Requisicao entity)
        {
            Requisicao request = GetById(entity.RequisicaoId);
            StatusRequisicao nextStep = GetNextStep(request.Status);

            request.Status = nextStep;
            request.StatusId = nextStep.StatusId;
            request.DataUltimaAtualizacao = DateTime.Now;

            if (nextStep.Descricao.Equals("Concluida"))
                request.DataFechamento = DateTime.Now;

            _context.Requisicao.Update(request);
            _context.SaveChanges();
        }

        private StatusRequisicao GetNextStep(StatusRequisicao statusRequisicao)
        {
            StatusRequisicao nextStep = new StatusRequisicao { StatusId = 1 };

            if (statusRequisicao.Descricao.Equals("Designada para Analista"))
            {
                nextStep = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals("Em Atendimento"));
            }
            else if (statusRequisicao.Descricao.Equals("Em Atendimento"))
            {
                nextStep = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals("Concluida"));
            }
            else if (statusRequisicao.Descricao.Equals("Concluida"))
            {
                nextStep = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals("Encerrada"));
            }
            else if (statusRequisicao.Descricao.Equals("Encerrada"))
            {
                nextStep = _context.StatusRequisicao
                .FirstOrDefault(p => p.Descricao.Equals("Encerrada"));
            }

            return nextStep;
        }

    }
}

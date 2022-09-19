using GestaoServicosApi.Models.Entities;
using GestaoServicosApi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoServicosApi.Models.Services
{
    public class RequisicaoServiceImpl : RequisicaoService
    {
        private readonly RequisicaoRepository _requisicaoRepository;

        public RequisicaoServiceImpl(RequisicaoRepository requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
        }

        public void Create(Requisicao entity)
        {
            try
            {
                _requisicaoRepository.Create(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _requisicaoRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Requisicao GetById(int id)
        {
            try
            {
                return _requisicaoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Requisicao> Read()
        {
            try
            {
                return _requisicaoRepository.Read();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Requisicao entity)
        {
            try
            {
                _requisicaoRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Simu.Business.Interfaces;
using Simu.Business.Models;
using Simu.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Services
{
    public class DadoService : BaseService, IDadoService
    {
        private readonly IDadoRepository _dadoRepository;

        public DadoService(IDadoRepository dadoRepository,
                             INotificador notificador)
        {
            _dadoRepository = dadoRepository;
        }

        public async Task Adicionar(Dado dado)
        {

            if (_dadoRepository.Buscar(t => t.Id == dado.Id).Result.Any())
            {
                Notificar("Esta tarefa já existe.");
            }

            await _dadoRepository.Adicionar(dado);
        }

        public async Task Atualizar(Models.Dado dado)
        {

            await _dadoRepository.Atualizar(dado);
        }

        public async Task Remover(Guid id)
        {
            await _dadoRepository.Remover(id);
        }
        public async Task BuscarDadosUsuario(Guid id)
        {
            await _dadoRepository.ObterDadosUsuario(id);

            //return null;
        }


        public void Dispose()
        {
            _dadoRepository?.Dispose();
        }


    }

}

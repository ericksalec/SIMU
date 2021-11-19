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
    public class QuestaoService : BaseService, IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;

        public QuestaoService(IQuestaoRepository questaoRepository,
                             INotificador notificador)
        {
            _questaoRepository = questaoRepository;
        }

        public async Task Adicionar(Questao questao)
        {

            if (_questaoRepository.Buscar(t => t.Id == questao.Id).Result.Any())
            {
                Notificar("Esta tarefa já existe.");
            }

            await _questaoRepository.Adicionar(questao);
        }

        public async Task Atualizar(Models.Questao questao)
        {

            await _questaoRepository.Atualizar(questao);
        }

        public async Task Remover(Guid id)
        {
            await _questaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _questaoRepository?.Dispose();
        }


    }

}

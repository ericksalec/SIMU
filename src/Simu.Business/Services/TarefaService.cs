using System;
using System.Linq;
using System.Threading.Tasks;
using Simu.Business.Interfaces;
using Simu.Business.Models;
using Simu.Business.Validations;


namespace Simu.Business.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository,
                             INotificador notificador) 
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task Adicionar(Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            if (_tarefaRepository.Buscar(t => t.Id == tarefa.Id).Result.Any())
            {
                Notificar("Esta tarefa já existe.");
            }

            await _tarefaRepository.Adicionar(tarefa);
        }

        public async Task Atualizar(Models.Tarefa tarefa)
        {
            if (!ExecutarValidacao(new TarefaValidation(), tarefa)) return;

            await _tarefaRepository.Atualizar(tarefa);
        }

        public async Task Remover(Guid id)
        {
            await _tarefaRepository.Remover(id);
        }
        public void Dispose()
        { 
            _tarefaRepository?.Dispose();
        }


    }
}
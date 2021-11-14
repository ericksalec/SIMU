using System;
using System.Threading.Tasks;
using Simu.Business.Models;

namespace Simu.Business.Interfaces
{
    public interface ITarefaService : IDisposable
    {
        Task Adicionar(Tarefa tarefa);
        Task Atualizar(Tarefa tarefa);
        Task Remover(Guid id);

    }

}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simu.Business.Models;

namespace Simu.Business.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<Tarefa> ObterTarefa(Guid id);
        Task<IEnumerable<Tarefa>> ObterTarefaUsuario(string usuarioId);
        Task<IEnumerable<Tarefa>> ObterTarefaUsuarioDone(string usuarioId);
        Task<IEnumerable<Tarefa>> ObterTarefas();
        Task<IEnumerable<Tarefa>> ObterProva(string prova);
        Task<IEnumerable<Tarefa>> ObterProvas();



    }
}

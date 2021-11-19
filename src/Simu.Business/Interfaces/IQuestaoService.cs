using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Interfaces
{
    public interface IQuestaoService : IDisposable
    {
        Task Adicionar(Questao tarefa);
        Task Atualizar(Questao tarefa);
        Task Remover(Guid id);
    }
}

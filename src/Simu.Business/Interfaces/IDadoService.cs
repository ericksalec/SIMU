using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Interfaces
{
    public interface IDadoService : IDisposable
    {
        Task Adicionar(Dado dado);
        Task Atualizar(Dado dado);
        Task Remover(Guid id);
    }
}

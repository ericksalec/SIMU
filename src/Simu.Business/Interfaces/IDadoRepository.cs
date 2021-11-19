using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Interfaces
{
    public interface IDadoRepository : IRepository<Dado>
    {
        Task<Questao> ObterDadosUsuario(Guid id);
        Task<IList<Questao>> ObterDados();
    }
}

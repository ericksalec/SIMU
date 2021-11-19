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
        Task<Dado> ObterDadosUsuario(Guid id);
        Task<Dado> ObterDadosUsuarioPorAno(Guid id, int anoProva);
        Task<IList<Dado>> ObterDados();
    }
}

using Microsoft.EntityFrameworkCore;
using Simu.Business.Interfaces;
using Simu.Business.Models;
using Simu.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Data.Repository
{
    public class DadoRepository : Repository<Dado>, IDadoRepository
    {
        public DadoRepository(SimuDbContext context) : base(context) { }

        public Task<IList<Questao>> ObterDados()
        {
            throw new NotImplementedException();
        }

        public Task<Questao> ObterDadosUsuario(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

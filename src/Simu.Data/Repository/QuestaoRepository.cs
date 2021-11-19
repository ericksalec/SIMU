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
    public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(SimuDbContext context) : base(context) { }

        public async Task<Questao> ObterQuestao(Guid id)
        {
            return await Db.Questoes.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IList<Questao>> ObterQuestoes()
        {
            return await Db.Questoes.AsNoTracking()
                .OrderBy(p => p.Numero)
                .ToListAsync();
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesProva(string prova)
        {
            return await Db.Questoes.AsNoTracking()
                .OrderBy(p => p.Numero)
                .Where(p => (p.Prova == prova))
                .ToListAsync();
        }

        public async Task<IEnumerable<Questao>> ObterProva(string prova)
        {
            return await Db.Questoes.AsNoTracking()
                .OrderBy(p => p.Prova)
                .Where(p => (p.Prova == prova))
                .ToListAsync();
        }


    }
}

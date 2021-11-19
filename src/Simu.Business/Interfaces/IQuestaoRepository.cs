using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simu.Business.Interfaces
{
    public interface IQuestaoRepository : IRepository<Questao>
    {
        Task<Questao> ObterQuestao(Guid id);
        Task<IList<Questao>> ObterQuestoes();
        Task<IEnumerable<Questao>> ObterQuestoesProva(string prova);
        Task<IEnumerable<Questao>> ObterProva(string prova);


    }
}

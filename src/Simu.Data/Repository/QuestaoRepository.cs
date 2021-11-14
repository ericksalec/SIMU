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

    }
}

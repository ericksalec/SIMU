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

        public Task<IList<Dado>> ObterDados()
        {
            throw new NotImplementedException();
        }


        public async Task<Dado> ObterDadosUsuario(Guid id)
        {
            var somaAcertos = 0;
            var somaErros = 0;
            var somaRespondidas = 0;

            var list = await Db.Dado.AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => (p.UserId == id))
                .ToListAsync();

            foreach (var item in list)
            {
                somaRespondidas = somaRespondidas + item.Respondidas;
                somaAcertos = somaAcertos + item.Acertos;
                somaErros = somaErros + item.Erros;
            }

            var dado = new Dado
            {
                Acertos = somaAcertos,
                Erros = somaErros,
                Respondidas = somaRespondidas,
                UserId = id,
            };

            return dado;
        }

        public async Task<Dado> ObterDadosUsuarioPorAno(Guid id, int anoProva)
        {
            var somaAcertos = 0;
            var somaErros = 0;
            var somaRespondidas = 0;

            var list = await Db.Dado.AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(p => (p.UserId == id && p.AnoProva == anoProva))
                .ToListAsync();

            foreach (var item in list)
            {
                somaRespondidas = somaRespondidas + item.Respondidas;
                somaAcertos = somaAcertos + item.Acertos;
                somaErros = somaErros + item.Erros;
            }

            var dado = new Dado
            {
                Acertos = somaAcertos,
                Erros = somaErros,
                Respondidas = somaRespondidas,
                UserId = id, 
                AnoProva = anoProva,
            };

            return dado;
        }
    }
}

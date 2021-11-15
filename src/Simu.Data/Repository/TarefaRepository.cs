using Simu.Business.Interfaces;
using Simu.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Simu.Data.Context;

namespace Simu.Data.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(SimuDbContext context) : base(context) { }

        public async Task<Tarefa> ObterTarefa(Guid id)
        {
            return await Db.Tarefas.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefas()
        {
            return await Db.Tarefas.AsNoTracking()
                .OrderBy(p => p.Titulo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefaUsuario(string usuarioId)
        {
            return await Db.Tarefas.AsNoTracking()
                .OrderBy(p => p.Titulo)
                .Where(p => (p.Ativo == false && p.UsuarioId == usuarioId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTarefaUsuarioDone(string usuarioId)
        {
            return await Db.Tarefas.AsNoTracking()
                .OrderBy(p => p.Titulo)
                .Where(p  => (p.Ativo == true && p.UsuarioId == usuarioId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterProva(string prova)
        {
            return await Db.Tarefas.AsNoTracking()
                .OrderBy(p => p.Titulo)
                .Where(p => (p.Prova == prova))
                .ToListAsync();
        }


    }
}
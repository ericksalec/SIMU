using Microsoft.EntityFrameworkCore;
using Simu.Business.Models;


namespace Simu.Data.Context
{
    public class SimuDbContext : DbContext
    {
        public SimuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Prova> Provas { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Dado> Dado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configurando o mapeamento das entidades 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

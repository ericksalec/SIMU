using Microsoft.EntityFrameworkCore;
using Simu.Business.Models;


namespace Simu.Data.Context
{
    public class SimuDbContext : DbContext
    {
        public SimuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configurando o mapeamento das entidades 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

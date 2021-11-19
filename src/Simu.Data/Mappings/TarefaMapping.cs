using Simu.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Simu.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TarefaId)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.UsuarioId)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(5000)");

            builder.Property(p => p.Imagem)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Prova)
                .HasColumnType("varchar(200)");

            builder.ToTable("Tarefas");

        }
    }
}

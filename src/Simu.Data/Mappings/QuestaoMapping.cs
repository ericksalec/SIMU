using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simu.Business.Models;

namespace Simu.Data.Mappings
{
    public class QuestaoMapping : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TarefaId);
            builder.Property(p => p.Enunciado)
                .IsRequired()
                .HasColumnType("varchar(5000)");
            builder.Property(p => p.Prova)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.Property(p => p.TipoAssunto)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");
            builder.Property(p => p.Resposta)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");
            builder.Property(p => p.AnoProva)
                 .IsRequired()
                 .HasColumnType("varchar(20)");
            builder.Property(p => p.A)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.Property(p => p.B)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");
            builder.Property(p => p.C)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");
            builder.Property(p => p.D)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");


            //1 : 1 => Questao: Prova
            //builder.HasOne(f => f.Prova)
            //    .WithOne(f => f.Questao);

            //1 : N => Questao : Assunto
            //object p = builder.HasMany(p => p.Assunto)
            //    .WithOne(p => p.Questao)
            //    .HasForeingKey(p => p.AssuntoId);

            builder.ToTable("Questao");

        }
    }
}

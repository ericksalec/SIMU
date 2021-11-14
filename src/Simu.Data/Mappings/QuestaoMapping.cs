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
            builder.Property(p => p.TarefaId)
                .IsRequired();
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(5000)");
            builder.Property(p => p.Prova)
                .IsRequired()
                .HasColumnType("varchar(200)");

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

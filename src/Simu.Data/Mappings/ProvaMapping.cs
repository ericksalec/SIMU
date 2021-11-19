using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simu.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simu.Data.Mappings
{
    public class ProvaMapping : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Questao)
            //    .IsRequired()
            //    .HasColumnType("varchar(10000)");
            builder.Property(p => p.Data)
                .IsRequired();


            //1 : 1 => Questao: Prova
            //builder.HasOne(f => f.Questao)
            //    .WithOne(f => f.Prova);

            ////1 : N => Questao : Prova
            //builder.HasMany(f => f.Questao)
            //    .WithOne(p => p.Prova)
            //    .HasForeingKey(p => p.QuestaoId);
            builder.ToTable("Prova");

        }
    }
}

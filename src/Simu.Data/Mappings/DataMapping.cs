using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simu.Business.Models;

namespace Simu.Data.Mappings
{
    public class DadoMapping : IEntityTypeConfiguration<Dado>
    {
        public void Configure(EntityTypeBuilder<Dado> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Dado");

        }
    }
}

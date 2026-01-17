using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolutions.Medicoes.Infrastructure.Database.Configurations;

public class PropriedadeConfiguration : IEntityTypeConfiguration<Propriedade>
{
    public void Configure(EntityTypeBuilder<Propriedade> builder)
    {
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
    }
}

using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolutions.Medicoes.Infrastructure.Database.Configurations;

public class ProdutorConfiguration : IEntityTypeConfiguration<Produtor>
{
    public void Configure(EntityTypeBuilder<Produtor> builder)
    {
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
    }
}

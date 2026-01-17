using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolutions.Medicoes.Infrastructure.Database.Configurations;

public class TalhaoConfiguration : IEntityTypeConfiguration<Talhao>
{
    public void Configure(EntityTypeBuilder<Talhao> builder)
    {
        builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
    }
}
using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolutions.Medicoes.Infrastructure.Database.Configurations;

public class AlertaConfiguration : IEntityTypeConfiguration<Alerta>
{
    public void Configure(EntityTypeBuilder<Alerta> builder)
    {
        builder.Property(c => c.IdTalhao).IsRequired();
        builder.Property(c => c.DataAlerta).IsRequired();
    }
}
using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolutions.Medicoes.Infrastructure.Database.Configurations;

public class MedicaoConfiguration : IEntityTypeConfiguration<Medicao>
{
    public void Configure(EntityTypeBuilder<Medicao> builder)
    {
        builder.Property(c => c.IdTalhao).IsRequired();
        builder.Property(c => c.DataMedicao).IsRequired();
        builder.Property(c => c.Tipo).IsRequired();
        builder.Property(c => c.Valor).IsRequired();
    }
}

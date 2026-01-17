using AgroSolutions.Medicoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgroSolutions.Medicoes.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Talhao> Talhoes { get; set; }
    public DbSet<Propriedade> Propriedades { get; set; }
    public DbSet<Medicao> Medicoes { get; set; }
    public DbSet<Produtor> Produtores { get; set; }
    public DbSet<Alerta> Alertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

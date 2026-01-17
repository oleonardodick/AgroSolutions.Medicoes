using AgroSolutions.Medicoes.Domain.Repositories;
using AgroSolutions.Medicoes.Infrastructure.Database;
using AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgroSolutions.Medicoes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<ITalhaoRepository, TalhaoRepository>();
        services.AddScoped<IMedicaoRepository, MedicaoRepository>();
        services.AddScoped<IPropriedadeRepository, PropriedadeRepository>();
        services.AddScoped<IProdutorRepository, ProdutorRepository>();

        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionsString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionsString);
            options.UseSnakeCaseNamingConvention();
        }, ServiceLifetime.Scoped);

        return services;
    }
}

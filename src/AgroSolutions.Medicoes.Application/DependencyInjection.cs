using AgroSolutions.Medicoes.Application.Interfaces.Services;
using AgroSolutions.Medicoes.Application.Rules.Abstractions;
using AgroSolutions.Medicoes.Application.Rules.Contexts;
using AgroSolutions.Medicoes.Application.Rules.Implementations.Temperatura;
using AgroSolutions.Medicoes.Application.Rules.Schedulers;
using AgroSolutions.Medicoes.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AgroSolutions.Medicoes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IMedicaoService, MedicaoService>();
        services.AddScoped<ITalhaoService, TalhaoService>();
        services.AddScoped<IPropriedadeService, PropriedadeService>();
        services.AddScoped<IProdutorService, ProdutorService>();
        services.AddScoped<IEmailService, MailKitEmailService>();

        services.AddScoped<IRuleScheduler, RegraPeriodoScheduler>();

        services.AddScoped<IRule<RegraPeriodoContext>, MediaAltaTemperaturaRule>();

        return services;
    }
}

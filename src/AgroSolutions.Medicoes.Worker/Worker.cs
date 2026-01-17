using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Rules.Schedulers;
using AgroSolutions.Medicoes.Domain.Enums;
using MassTransit;

namespace AgroSolutions.Medicoes.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IBus _bus;
    private readonly IServiceScopeFactory _scopeFactory;
    private static readonly TimeSpan INTERVALO = TimeSpan.FromMinutes(30);

    public Worker(ILogger<Worker> logger, IBus bus, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _bus = bus;
        _scopeFactory = scopeFactory;
    }

    // protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    // {
    //     while (!stoppingToken.IsCancellationRequested)
    //     {
    //         if (_logger.IsEnabled(LogLevel.Information))
    //         {
    //             _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    //         }

    //         var message = new SensorDataMessage(
    //             TalhaoId: Guid.NewGuid(),
    //             DataMedicao: DateTime.UtcNow,
    //             Tipo: TipoMedicao.Umidade,
    //             Valor: Random.Shared.Next(10, 90)
    //         );

    //         await _bus.Publish(message, stoppingToken);
            
    //         await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
    //     }
    // }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var scheduler = scope.ServiceProvider.GetRequiredService<IRuleScheduler>();

                await scheduler.ExecuteAsync(stoppingToken);
            }
            catch (OperationCanceledException)
            {
                //log da operação cancelada
            }
            catch(Exception ex)
            {
                //log das outras exceções
                _logger.LogError(ex, "Erro ao executar regras periódicas");
            }

            await Task.Delay(INTERVALO, stoppingToken);
        }
    }
}

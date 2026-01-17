using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MassTransit;

namespace AgroSolutions.Medicoes.Worker.Consumers;

public class SensorDataConsumer(IMedicaoService _service): IConsumer<SensorDataMessage>
{
    public async Task Consume(ConsumeContext<SensorDataMessage> context)
    {
        var msg = context.Message;

        await _service.ProcessarAsync(msg, context.CancellationToken);
    }
}

using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MassTransit;

namespace AgroSolutions.Medicoes.Worker.Consumers;

public class TalhaoDataConsumer(ITalhaoService _service) : IConsumer<TalhaoDataMessage>
{
    public async Task Consume(ConsumeContext<TalhaoDataMessage> context)
    {
        var msg = context.Message;

        await _service.ProcessarAsync(msg, context.CancellationToken);
    }
}

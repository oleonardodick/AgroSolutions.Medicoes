using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MassTransit;

namespace AgroSolutions.Medicoes.Worker.Consumers;

public class PropriedadeDataConsumer(IPropriedadeService _service) : IConsumer<PropriedadeDataMessage>
{
    public async Task Consume(ConsumeContext<PropriedadeDataMessage> context)
    {
        var msg = context.Message;

        await _service.ProcessarAsync(msg, context.CancellationToken);
    }
}

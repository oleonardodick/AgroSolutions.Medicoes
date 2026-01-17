using AgroSolutions.Medicoes.Application.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MassTransit;

namespace AgroSolutions.Medicoes.Worker.Consumers;

public class ProdutorDataConsumer(IProdutorService _service) : IConsumer<ProdutorDataMessage>
{
    public async Task Consume(ConsumeContext<ProdutorDataMessage> context)
    {
        var msg = context.Message;

        await _service.ProcessarAsync(msg, context.CancellationToken);
    }
}

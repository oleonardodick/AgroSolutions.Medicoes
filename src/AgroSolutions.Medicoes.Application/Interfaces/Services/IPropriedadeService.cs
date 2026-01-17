using AgroSolutions.Contracts;

namespace AgroSolutions.Medicoes.Application.Interfaces.Services;

public interface IPropriedadeService
{
    Task ProcessarAsync(PropriedadeDataMessage propriedadeData, CancellationToken cancellationToken);
}

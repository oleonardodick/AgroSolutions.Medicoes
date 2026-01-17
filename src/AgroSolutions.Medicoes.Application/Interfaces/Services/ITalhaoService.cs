using AgroSolutions.Contracts;

namespace AgroSolutions.Medicoes.Application.Interfaces.Services;

public interface ITalhaoService
{
    Task ProcessarAsync(TalhaoDataMessage talhaoData, CancellationToken cancellationToken);
}

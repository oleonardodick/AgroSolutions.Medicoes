using AgroSolutions.Medicoes.Application.Contracts;

namespace AgroSolutions.Medicoes.Application.Interfaces.Services;

public interface IProdutorService
{
    Task ProcessarAsync(ProdutorDataMessage produtorData, CancellationToken cancellationToken);
}

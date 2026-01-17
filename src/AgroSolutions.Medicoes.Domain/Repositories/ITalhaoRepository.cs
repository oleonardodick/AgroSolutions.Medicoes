using AgroSolutions.Medicoes.Domain.Entities;

namespace AgroSolutions.Medicoes.Domain.Repositories;

public interface ITalhaoRepository
{
    Task AddAsync(Talhao talhao, CancellationToken cancellationToken);
}

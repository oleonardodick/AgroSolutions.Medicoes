using AgroSolutions.Medicoes.Domain.Entities;

namespace AgroSolutions.Medicoes.Domain.Repositories;

public interface IPropriedadeRepository
{
    Task AddAsync(Propriedade propriedade, CancellationToken cancellationToken);
}

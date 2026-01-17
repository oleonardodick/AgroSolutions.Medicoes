using AgroSolutions.Medicoes.Domain.Entities;

namespace AgroSolutions.Medicoes.Domain.Repositories;

public interface IProdutorRepository
{
    Task AddAsync(Produtor produtor, CancellationToken cancellationToken);
}

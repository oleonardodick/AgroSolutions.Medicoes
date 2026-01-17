using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Domain.Repositories;

public interface IMedicaoRepository
{
    Task AddAsync(Medicao medicao, CancellationToken cancellationToken);
}

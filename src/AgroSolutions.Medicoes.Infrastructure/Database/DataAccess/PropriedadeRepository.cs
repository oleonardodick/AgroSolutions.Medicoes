using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class PropriedadeRepository(AppDbContext _db) : IPropriedadeRepository
{
    public async Task AddAsync(Propriedade propriedade, CancellationToken cancellationToken)
    {
        _db.Propriedades.Add(propriedade);

        await _db.SaveChangesAsync(cancellationToken);
    }
}

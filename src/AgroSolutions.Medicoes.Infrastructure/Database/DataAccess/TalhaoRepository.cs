using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class TalhaoRepository(AppDbContext _db) : ITalhaoRepository
{
    public async Task AddAsync(Talhao talhao, CancellationToken cancellationToken)
    {
        _db.Talhoes.Add(talhao);

        await _db.SaveChangesAsync(cancellationToken);
    }
}

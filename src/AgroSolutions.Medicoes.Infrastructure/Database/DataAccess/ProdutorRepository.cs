using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class ProdutorRepository(AppDbContext _db) : IProdutorRepository
{
    public async Task AddAsync(Produtor produtor, CancellationToken cancellationToken)
    {
        _db.Produtores.Add(produtor);

        await _db.SaveChangesAsync(cancellationToken);
    }
}

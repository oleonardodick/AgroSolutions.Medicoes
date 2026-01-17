using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class MedicaoRepository(AppDbContext _db) : IMedicaoRepository
{
    public async Task AddAsync(Medicao medicao, CancellationToken cancellationToken)
    {
        _db.Medicoes.Add(medicao);

        await _db.SaveChangesAsync(cancellationToken);
    }
}

using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class AlertaRepository(AppDbContext _db) : IAlertaRepository
{
    public async Task AddAsync(Alerta alerta, CancellationToken cancellationToken)
    {
        _db.Alertas.Add(alerta);

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Guid idTalhao, DateTime dataCorte, TipoMedicao tipo, CancellationToken cancellationToken)
    {
        return await _db.Alertas.AnyAsync(a =>
            a.IdTalhao == idTalhao &&
            a.Tipo == tipo &&
            a.DataAlerta >= dataCorte,
            cancellationToken
        );
    }
}

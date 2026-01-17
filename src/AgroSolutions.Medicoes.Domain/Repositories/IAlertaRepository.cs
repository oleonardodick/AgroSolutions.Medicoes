using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Domain.Repositories;

public interface IAlertaRepository
{
    Task AddAsync(Alerta alerta, CancellationToken cancellationToken);

    Task<bool> ExistsAsync(Guid idTalhao, DateTime dataCorte, TipoMedicao tipo, CancellationToken cancellationToken);
}

using AgroSolutions.Medicoes.Application.DTOs;
using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Application.Interfaces.Queries;

public interface IAlertaMedicaoQueryRepository
{
    Task<List<MedicaoMediaDTO>> ObtemMedicaoMediaAsync(TipoMedicao tipo, DateTime inicio, DateTime fim, CancellationToken cancellationToken);
}

using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Application.Services;

public class MedicaoService(IMedicaoRepository _repository) : IMedicaoService
{
    public async Task ProcessarAsync(SensorDataMessage sensorData, CancellationToken cancellationToken)
    {
        var medicao = new Medicao(
            sensorData.TalhaoId,
            sensorData.DataMedicao,
            sensorData.Tipo,
            sensorData.Valor
        );

        await _repository.AddAsync(medicao, cancellationToken);
    }
}

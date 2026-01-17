using AgroSolutions.Contracts;

namespace AgroSolutions.Medicoes.Application.Interfaces.Services;

public interface IMedicaoService
{
    Task ProcessarAsync(SensorDataMessage sensorData, CancellationToken cancellationToken);
}

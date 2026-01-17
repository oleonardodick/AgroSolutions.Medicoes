using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Contracts;

public record SensorDataMessage(
    Guid TalhaoId,
    DateTime DataMedicao,
    TipoMedicao Tipo,
    double Valor
);

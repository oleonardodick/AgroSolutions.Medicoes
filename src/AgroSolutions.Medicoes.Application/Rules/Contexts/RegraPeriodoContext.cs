using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Application.Rules.Contexts;

public record RegraPeriodoContext
(
    TipoMedicao Tipo,
    DateTime DataReferencia
);

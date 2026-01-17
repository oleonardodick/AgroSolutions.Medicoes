
using AgroSolutions.Medicoes.Application.Rules.Abstractions;
using AgroSolutions.Medicoes.Application.Rules.Contexts;
using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Application.Rules.Schedulers;

public class RegraPeriodoScheduler(IEnumerable<IRule<RegraPeriodoContext>> _rules) : IRuleScheduler
{
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var dataReferencia = DateTime.UtcNow;

        foreach(var tipo in Enum.GetValues<TipoMedicao>())
        {
            var context = new RegraPeriodoContext(
                Tipo: tipo,
                DataReferencia: dataReferencia
            );

            foreach(var rule in _rules.Where(r => r.IsApplicable(context)))
            {
                if(cancellationToken.IsCancellationRequested)
                    return;

                await rule.ValidateAsync(context, cancellationToken);
            }
        }
    }
}

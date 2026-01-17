namespace AgroSolutions.Medicoes.Application.Rules.Schedulers;

public interface IRuleScheduler
{
     Task ExecuteAsync(CancellationToken cancellationToken);
}

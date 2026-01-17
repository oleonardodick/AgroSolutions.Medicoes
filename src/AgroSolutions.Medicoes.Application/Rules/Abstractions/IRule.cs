namespace AgroSolutions.Medicoes.Application.Rules.Abstractions;

public interface IRule<TContext>
{
    bool IsApplicable(TContext context);
    Task ValidateAsync(TContext context, CancellationToken cancellationToken);
}

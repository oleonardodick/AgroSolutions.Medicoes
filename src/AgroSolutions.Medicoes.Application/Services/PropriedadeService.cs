using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Application.Services;

public class PropriedadeService(IPropriedadeRepository _repository) : IPropriedadeService
{
    public async Task ProcessarAsync(PropriedadeDataMessage propriedadeData, CancellationToken cancellationToken)
    {
        var propriedade = new Propriedade(
            propriedadeData.PropriedadeId,
            propriedadeData.Nome,
            propriedadeData.ProdutorId
        );

        await _repository.AddAsync(propriedade, cancellationToken);
    }
}

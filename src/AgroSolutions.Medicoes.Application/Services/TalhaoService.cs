using AgroSolutions.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Application.Services;

public class TalhaoService(ITalhaoRepository _repository) : ITalhaoService
{
    public async Task ProcessarAsync(TalhaoDataMessage talhaoData, CancellationToken cancellationToken)
    {
        var talhao = new Talhao(
            talhaoData.TalhaoId,
            talhaoData.Nome,
            talhaoData.PropriedadeId
        );

        await _repository.AddAsync(talhao, cancellationToken);
    }
}

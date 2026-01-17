using AgroSolutions.Medicoes.Application.Contracts;
using AgroSolutions.Medicoes.Application.Interfaces.Services;
using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Repositories;

namespace AgroSolutions.Medicoes.Application.Services;

public class ProdutorService(IProdutorRepository _repository) : IProdutorService
{
    public async Task ProcessarAsync(ProdutorDataMessage produtorData, CancellationToken cancellationToken)
    {
        var produtor = new Produtor(
            produtorData.ProdutorId,
            produtorData.Email
        );

        await _repository.AddAsync(produtor, cancellationToken);
    }
}

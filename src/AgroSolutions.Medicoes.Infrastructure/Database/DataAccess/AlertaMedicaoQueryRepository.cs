using AgroSolutions.Medicoes.Application.DTOs;
using AgroSolutions.Medicoes.Application.Interfaces.Queries;
using AgroSolutions.Medicoes.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AgroSolutions.Medicoes.Infrastructure.Database.DataAccess;

public class AlertaMedicaoQueryRepository(AppDbContext _db) : IAlertaMedicaoQueryRepository
{
    public async Task<List<MedicaoMediaDTO>> ObtemMedicaoMediaAsync(TipoMedicao tipo, DateTime inicio, DateTime fim, CancellationToken cancellationToken)
    {
        var query =
            from medicao in _db.Medicoes
            where medicao.DataMedicao >= inicio && medicao.DataMedicao <= fim
            group medicao by new
            {
                medicao.IdTalhao
            }
            into g
            select new
            {
                TalhaoId = g.Key.IdTalhao,
                Media = g.Average(x => x.Valor)
            };

        var resultado = 
            from media in query
            join talhao in _db.Talhoes
                on media.TalhaoId equals talhao.Id
            join propriedade in _db.Propriedades
                on talhao.IdPropriedade equals propriedade.Id
            join produtor in _db.Produtores
                on propriedade.IdProdutor equals produtor.Id
            select new MedicaoMediaDTO
            {
                IdTalhao = talhao.Id,
                NomeTalhao = talhao.Nome,
                NomePropriedade = propriedade.Nome,
                EmailProdutor = produtor.Email,
                MediaValor = media.Media
            };

        return await resultado.ToListAsync(cancellationToken);
    }
}

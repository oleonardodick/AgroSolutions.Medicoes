using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public class Alerta : Base
{
    public Guid IdTalhao { get; private set; }
    public DateTime DataAlerta { get; private set; }
    public TipoMedicao Tipo { get; private set; }

    protected Alerta() { }

    public Alerta(Guid idTalhao, DateTime dataAlerta, TipoMedicao tipo)
    :base(Guid.NewGuid())
    {
        DefinirTalhao(idTalhao);
        DefinirDataAlerta(dataAlerta);
        DefinirTipo(tipo);
    }

    public void DefinirTalhao(Guid idTalhao)
    {
        if(idTalhao == Guid.Empty)
            throw new DomainException("O Id do talhão é obrigatório.");

        IdTalhao = idTalhao;
    }

    public void DefinirDataAlerta(DateTime dataAlerta)
    {
        if(dataAlerta == DateTime.MinValue)
            throw new DomainException("A data do alerta é obrigatória.");

        DataAlerta = dataAlerta;
    }

    public void DefinirTipo(TipoMedicao tipo)
    {
        if(!Enum.IsDefined(typeof(TipoMedicao), tipo))
            throw new DomainException("Tipo de alerta inválido.");

        Tipo = tipo;
    }
}

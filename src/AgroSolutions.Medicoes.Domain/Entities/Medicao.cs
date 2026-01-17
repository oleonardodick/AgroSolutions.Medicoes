using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public class Medicao : Base
{
    public Guid IdTalhao { get; private set; }
    public DateTime DataMedicao { get; private set; }
    public TipoMedicao Tipo { get; private set; }
    public double Valor { get; private set; }

    protected Medicao() { }

    public Medicao(
        Guid idTalhao, 
        DateTime dataMedicao, 
        TipoMedicao tipo,
        double valor)
        :base(Guid.NewGuid())
    {
        DefinirTalhao(idTalhao);
        DefinirDataMedicao(dataMedicao);
        DefinirTipo(tipo);
        DefinirValor(valor);
    }

    public void DefinirTalhao(Guid idTalhao)
    {
        if(idTalhao == Guid.Empty)
            throw new DomainException("O Id do talhão é obrigatório.");

        IdTalhao = idTalhao;
    }

    public void DefinirDataMedicao(DateTime dataMedicao)
    {
        if(dataMedicao == DateTime.MinValue)
            throw new DomainException("A data de medição é obrigatória.");
        DataMedicao = dataMedicao;
    }

    public void DefinirTipo(TipoMedicao tipo)
    {
        if(!Enum.IsDefined(typeof(TipoMedicao), tipo))
            throw new DomainException("Tipo de medição inválido.");

        Tipo = tipo;
    }

    public void DefinirValor(double valor)
    {
        if(Tipo != TipoMedicao.Temperatura && valor < 0)
            throw new DomainException("O valor da medição não pode ser negativa para esse tipo de medição.");
            
        Valor = valor;
    }
}
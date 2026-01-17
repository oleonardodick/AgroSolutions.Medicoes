using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public class Talhao : Base
{
    public string Nome { get; private set; } = string.Empty;
    public Guid IdPropriedade { get; private set; }

    protected Talhao() { }

    public Talhao(Guid id, string nome, Guid idPropriedade): base(id)
    {
        DefinirNome(nome);
        DefinirPropriedade(idPropriedade);
    }

    public void DefinirNome(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome do talhão é obrigatório.");

        Nome = nome;
    }

    public void DefinirPropriedade(Guid idPropriedade)
    {
        if(idPropriedade == Guid.Empty)
            throw new DomainException("O Id da propriedade é obrigatório.");

        IdPropriedade = idPropriedade;
    }
}

using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public class Propriedade : Base
{
    public string Nome { get; private set; } = string.Empty;
    public Guid IdProdutor { get; private set; }

    protected Propriedade() { }

    public Propriedade(Guid id, string nome, Guid idProdutor)
    :base(id)
    {
        DefinirNome(nome);
        DefinirProdutor(idProdutor);
    }

    public void DefinirNome(string nome)
    {
        if(string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome da propriedade é obrigatório.");

        Nome = nome;
    }

    public void DefinirProdutor(Guid idProdutor)
    {
        if(idProdutor == Guid.Empty)
            throw new DomainException("O id do produtor é obrigatório.");

        IdProdutor = idProdutor;
    }
}
using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public class Produtor : Base
{
    public string Email { get; private set; } = string.Empty;

    protected Produtor() { }

    public Produtor(Guid produtorId, string email)
        : base(produtorId)
    {
        DefinirEmail(email);
    }

    public void DefinirEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
            throw new DomainException("O Email do produtor deve é obrigatório.");

        Email = email;
    }
}

using AgroSolutions.Medicoes.Domain.Exceptions;

namespace AgroSolutions.Medicoes.Domain.Entities;

public abstract class Base
{
    public Guid Id { get; protected set; }

    protected Base(Guid id)
    {
        if(id == Guid.Empty)
            throw new DomainException("O Id é obrigatório.");

        Id = id;
    }

    protected Base() { } 
}
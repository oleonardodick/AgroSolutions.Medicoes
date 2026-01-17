using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Exceptions;
using Shouldly;

namespace AgroSolutions.Medicoes.Domain.Tests;

public class PropriedadeTests
{
   #region Construtor
    [Fact]
    public void Deve_criar_propriedade_com_dados_validos()
    {
        // Arrange
        var id = Guid.NewGuid();
        var nome = "Propriedade A";
        var produtorId = Guid.NewGuid();

        // Act
        var propriedade = new Propriedade(id, nome, produtorId);

        // Assert
        propriedade.ShouldNotBeNull();
        propriedade.Nome.ShouldBe(nome);
        propriedade.IdProdutor.ShouldBe(produtorId);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nao_deve_criar_propriedade_com_nome_invalido(string nomeInvalido)
    {
        //Arrange
        var id = Guid.NewGuid();
        var produtorId = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Propriedade(id, nomeInvalido, produtorId)
        );

        // Assert
        exception.Message.ShouldBe("O nome da propriedade é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_propriedade_com_id_vazio()
    {
        // Arrange
        var nome = "Propriedade A";
        var produtorId = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Propriedade(Guid.Empty, nome, produtorId)
        );

        // Assert
        exception.Message.ShouldBe("O Id é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_propriedade_sem_produtor()
    {
        // Arrange
        var nome = "Propriedade A";
        var produtorId = Guid.Empty;

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Propriedade(Guid.NewGuid(), nome, produtorId)
        );

        // Assert
        exception.Message.ShouldBe("O id do produtor é obrigatório.");
    }

    #endregion

    #region DefinirNome
    [Fact]
    public void Deve_definir_nome_valido()
    {
        // Arrange
        var propriedade = CriarPropriedadeValida();
        var novoNome = "Talhão B";

        // Act
        propriedade.DefinirNome(novoNome);

        // Assert
        propriedade.Nome.ShouldBe(novoNome);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nao_deve_definir_nome_invalido(string nomeInvalido)
    {
        // Arrange
        var propriedade = CriarPropriedadeValida();

        // Act
        var exception = Should.Throw<DomainException>(
            () => propriedade.DefinirNome(nomeInvalido)
        );

        // Assert
        exception.Message.ShouldBe("O nome da propriedade é obrigatório.");
    }

    #endregion

    #region Definir Produtor

    [Fact]
    public void Deve_definir_produtor_valido()
    {
        // Arrange
        var propriedade = CriarPropriedadeValida();
        var novoProdutor = Guid.NewGuid();

        // Act
        propriedade.DefinirProdutor(novoProdutor);

        // Assert
        propriedade.IdProdutor.ShouldBe(novoProdutor);
    }

    [Fact]
    public void Nao_deve_definir_produtor_invalido()
    {
        // Arrange
        var propriedade = CriarPropriedadeValida();

        // Act
        var exception = Should.Throw<DomainException>(
            () => propriedade.DefinirProdutor(Guid.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O id do produtor é obrigatório.");
    }

    #endregion

    #region Helpers

    private static Propriedade CriarPropriedadeValida()
        => new(Guid.NewGuid(), "Propriedade Teste", Guid.NewGuid());

    #endregion
}

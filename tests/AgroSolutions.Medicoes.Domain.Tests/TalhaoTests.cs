using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Exceptions;
using Shouldly;

namespace AgroSolutions.Medicoes.Domain.Tests;

public class TalhaoTests
{
    #region Construtor

    [Fact]
    public void Deve_criar_talhao_com_dados_validos()
    {
        // Arrange
        var nome = "Talhão A";
        var idPropriedade = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var talhao = new Talhao(id, nome, idPropriedade);

        // Assert
        talhao.ShouldNotBeNull();
        talhao.Id.ShouldBe(id);
        talhao.Nome.ShouldBe(nome);
        talhao.IdPropriedade.ShouldBe(idPropriedade);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nao_deve_criar_talhao_com_nome_invalido(string nomeInvalido)
    {
        // Arrange
        var idPropriedade = Guid.NewGuid();
        var id = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Talhao(id, nomeInvalido, idPropriedade)
        );

        // Assert
        exception.Message.ShouldBe("O nome do talhão é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_talhao_com_id_propriedade_vazio()
    {
        // Arrange
        var nome = "Talhão A";
        var id = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Talhao(id, nome, Guid.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O Id da propriedade é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_talhao_com_id_vazio()
    {
        // Arrange
        var nome = "Talhão A";
        var propriedadeId = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Talhao(Guid.Empty, nome, propriedadeId)
        );

        // Assert
        exception.Message.ShouldBe("O Id é obrigatório.");
    }

    #endregion

    #region DefinirNome

    [Fact]
    public void Deve_definir_nome_valido()
    {
        // Arrange
        var talhao = CriarTalhaoValido();
        var novoNome = "Talhão B";

        // Act
        talhao.DefinirNome(novoNome);

        // Assert
        talhao.Nome.ShouldBe(novoNome);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nao_deve_definir_nome_invalido(string nomeInvalido)
    {
        // Arrange
        var talhao = CriarTalhaoValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => talhao.DefinirNome(nomeInvalido)
        );

        // Assert
        exception.Message.ShouldBe("O nome do talhão é obrigatório.");
    }

    #endregion

    #region DefinirPropriedade

    [Fact]
    public void Deve_definir_id_propriedade_valido()
    {
        // Arrange
        var talhao = CriarTalhaoValido();
        var novoId = Guid.NewGuid();

        // Act
        talhao.DefinirPropriedade(novoId);

        // Assert
        talhao.IdPropriedade.ShouldBe(novoId);
    }

    [Fact]
    public void Nao_deve_definir_id_propriedade_vazio()
    {
        // Arrange
        var talhao = CriarTalhaoValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => talhao.DefinirPropriedade(Guid.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O Id da propriedade é obrigatório.");
    }

    #endregion

    #region Helpers

    private static Talhao CriarTalhaoValido()
        => new(Guid.NewGuid(), "Talhão Teste", Guid.NewGuid());

    #endregion
}

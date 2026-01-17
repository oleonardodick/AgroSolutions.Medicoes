using System;
using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Exceptions;
using Shouldly;

namespace AgroSolutions.Medicoes.Domain.Tests;

public class ProdutorTests
{
    #region Construtor
    [Fact]
    public void Deve_criar_produtor_com_dados_validos()
    {
        // Arrange
        var id = Guid.NewGuid();
        var email = "mail@test.com";

        // Act
        var produtor = new Produtor(id, email);

        // Assert
        produtor.ShouldNotBeNull();
        produtor.Email.ShouldBe(email);
        produtor.Id.ShouldBe(id);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Nao_deve_criar_produtor_com_email_invalido(string emailInvalido)
    {
        //Arrange
        var id = Guid.NewGuid();

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Produtor(id, emailInvalido)
        );

        // Assert
        exception.Message.ShouldBe("O Email do produtor deve é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_produtor_com_id_vazio()
    {
        // Arrange
        var email = "mail@test.com";

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Produtor(Guid.Empty, email)
        );

        // Assert
        exception.Message.ShouldBe("O Id é obrigatório.");
    }

    #endregion

     #region Definir Produtor

    [Fact]
    public void Deve_definir_email_valido()
    {
        // Arrange
        var produtor = CriarProdutorValido();
        var novoEmail = "new@mail.com";

        // Act
        produtor.DefinirEmail(novoEmail);

        // Assert
        produtor.Email.ShouldBe(novoEmail);
    }

    [Fact]
    public void Nao_deve_definir_email_invalido()
    {
        // Arrange
        var produtor = CriarProdutorValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => produtor.DefinirEmail(string.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O Email do produtor deve é obrigatório.");
    }

    #endregion

    #region Helpers

    private static Produtor CriarProdutorValido()
        => new(Guid.NewGuid(), "mail@test.com");

    #endregion
}

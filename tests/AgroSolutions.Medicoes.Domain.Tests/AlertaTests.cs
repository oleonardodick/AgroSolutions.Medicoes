using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Exceptions;
using Shouldly;

namespace AgroSolutions.Medicoes.Domain.Tests;

public class AlertaTests
{
    #region Constructor

    [Fact]
    public void Deve_criar_alerta_com_dados_validos()
    {
        // Act
        var idTalhao = Guid.NewGuid();
        var dataAlerta = DateTime.UtcNow;
        var alerta = new Alerta(idTalhao,dataAlerta, TipoMedicao.Precipitacao);

        // Assert
        alerta.ShouldNotBeNull();
        alerta.IdTalhao.ShouldBe(idTalhao);
        alerta.DataAlerta.ShouldBe(dataAlerta);
    }

    [Fact]
    public void Nao_deve_criar_alerta_com_id_talhao_vazio()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Alerta(Guid.Empty, DateTime.UtcNow, TipoMedicao.Precipitacao)
        );

        // Assert
        exception.Message.ShouldBe("O Id do talhão é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_alerta_com_data_alerta_invalida()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Alerta(Guid.NewGuid(), DateTime.MinValue, TipoMedicao.Precipitacao)
        );

        // Assert
        exception.Message.ShouldBe("A data do alerta é obrigatória.");
    }

    [Fact]
    public void Nao_deve_criar_alerta_com_tipo_invalido()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Alerta(Guid.NewGuid(), DateTime.UtcNow, (TipoMedicao)99)
        );

        // Assert
        exception.Message.ShouldBe("Tipo de alerta inválido.");
    }

    #endregion

    #region DefinirTalhao

    [Fact]
    public void Deve_definir_id_talhao_valido()
    {
        // Arrange
        var alerta = CriarAlertaValido();
        var novoId = Guid.NewGuid();

        // Act
        alerta.DefinirTalhao(novoId);

        // Assert
        alerta.IdTalhao.ShouldBe(novoId);
    }

    [Fact]
    public void Nao_deve_definir_id_talhao_vazio()
    {
        // Arrange
        var alerta = CriarAlertaValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => alerta.DefinirTalhao(Guid.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O Id do talhão é obrigatório.");
    }

    #endregion

    #region DefinirDataAlerta

    [Fact]
    public void Deve_definir_data_alerta_valida()
    {
        // Arrange
        var alerta = CriarAlertaValido();
        var novaData = DateTime.UtcNow;

        // Act
        alerta.DefinirDataAlerta(novaData);

        // Assert
        alerta.DataAlerta.ShouldBe(novaData);
    }

    [Fact]
    public void Nao_deve_definir_data_alerta_invalida()
    {
        // Arrange
        var alerta = CriarAlertaValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => alerta.DefinirDataAlerta(DateTime.MinValue)
        );

        // Assert
        exception.Message.ShouldBe("A data do alerta é obrigatória.");
    }

    #endregion

    #region DefinirTipo

    [Fact]
    public void Deve_definir_tipo_valido()
    {
        // Arrange
        var alerta = CriarAlertaValido();
        var novoTipo = TipoMedicao.Umidade;

        // Act
        alerta.DefinirTipo(novoTipo);

        // Assert
        alerta.Tipo.ShouldBe(novoTipo);
    }

    [Fact]
    public void Nao_deve_definir_tipo_invalido()
    {
        // Arrange
        var alerta = CriarAlertaValido();

        // Act
        var exception = Should.Throw<DomainException>(
            () => alerta.DefinirTipo((TipoMedicao)99)
        );

        // Assert
        exception.Message.ShouldBe("Tipo de alerta inválido.");
    }

    #endregion

    #region Helpers

    private static Alerta CriarAlertaValido()
        => new(Guid.NewGuid(), DateTime.UtcNow, TipoMedicao.Temperatura);

    #endregion
}
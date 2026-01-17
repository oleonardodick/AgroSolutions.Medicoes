using AgroSolutions.Medicoes.Domain.Entities;
using AgroSolutions.Medicoes.Domain.Enums;
using AgroSolutions.Medicoes.Domain.Exceptions;
using Shouldly;

namespace AgroSolutions.Medicoes.Domain.Tests;

public class MedicaoTests
{
    private static readonly Guid idTalhao = Guid.NewGuid();
    private static readonly DateTime dataMedicao = DateTime.Now;
    private static readonly TipoMedicao tipo = TipoMedicao.Temperatura;
    private static readonly double valor = 10.5;

    #region Constructor
    [Fact]
    public void Deve_criar_medicao_com_dados_validos()
    {
        // Act
        var medicao = new Medicao(idTalhao, dataMedicao, tipo, valor);

        // Assert
        medicao.ShouldNotBeNull();
        medicao.IdTalhao.ShouldBe(idTalhao);
        medicao.DataMedicao.ShouldBe(dataMedicao);
        medicao.Tipo.ShouldBe(tipo);
        medicao.Valor.ShouldBe(valor);
    }

    [Fact]
    public void Nao_deve_criar_medicao_com_id_talhao_vazio()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Medicao(Guid.Empty, dataMedicao, tipo, valor)
        );

        // Assert
        exception.Message.ShouldBe("O Id do talhão é obrigatório.");
    }

    [Fact]
    public void Nao_deve_criar_medicao_com_data_medicao_invalida()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Medicao(idTalhao, DateTime.MinValue, tipo, valor)
        );

        // Assert
        exception.Message.ShouldBe("A data de medição é obrigatória.");
    }

    [Fact]
    public void Nao_deve_criar_medicao_com_tipo_invalido()
    {
        // Act
        var exception = Should.Throw<DomainException>(
            () => new Medicao(idTalhao, dataMedicao, (TipoMedicao)99, valor)
        );

        // Assert
        exception.Message.ShouldBe("Tipo de medição inválido.");
    }

    [Theory]
    [InlineData(TipoMedicao.Precipitacao)]
    [InlineData(TipoMedicao.Umidade)]
    public void Nao_deve_criar_medicao_com_valor_negativo_quando_nao_temperatura(TipoMedicao tipoMedicao)
    {
        // Arrange
        var valorInvalido = -5;

        // Act
        var exception = Should.Throw<DomainException>(
            () => new Medicao(idTalhao, dataMedicao, tipoMedicao, valorInvalido)
        );

        // Assert
        exception.Message.ShouldBe("O valor da medição não pode ser negativa para esse tipo de medição.");
    }

    [Fact]
    public void Deve_criar_medicao_com_tipo_negativo_quando_temperatura()
    {
        //Assert
        var tipoMedicao = TipoMedicao.Temperatura;
        var valorMedicao = -10;

        // Act
        var medicao = new Medicao(idTalhao, dataMedicao, tipoMedicao, valorMedicao);

        // Assert
        medicao.ShouldNotBeNull();
        medicao.IdTalhao.ShouldBe(idTalhao);
        medicao.DataMedicao.ShouldBe(dataMedicao);
        medicao.Tipo.ShouldBe(tipoMedicao);
        medicao.Valor.ShouldBe(valorMedicao);
    }

    #endregion

    #region DefinirTalhao

    [Fact]
    public void Deve_definir_id_talhao_valido()
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novoId = Guid.NewGuid();

        // Act
        medicao.DefinirTalhao(novoId);

        // Assert
        medicao.IdTalhao.ShouldBe(novoId);
    }

    [Fact]
    public void Nao_deve_definir_id_talhao_vazio()
    {
        // Arrange
        var medicao = CriarMedicaoValida();

        // Act
        var exception = Should.Throw<DomainException>(
            () => medicao.DefinirTalhao(Guid.Empty)
        );

        // Assert
        exception.Message.ShouldBe("O Id do talhão é obrigatório.");
    }

    #endregion

    #region DefinirDataMedicao

    [Fact]
    public void Deve_definir_data_medicao_valida()
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novaData = DateTime.Now;

        // Act
        medicao.DefinirDataMedicao(novaData);

        // Assert
        medicao.DataMedicao.ShouldBe(novaData);
    }

    [Fact]
    public void Nao_deve_definir_data_medicao_invalida()
    {
        // Arrange
        var medicao = CriarMedicaoValida();

        // Act
        var exception = Should.Throw<DomainException>(
            () => medicao.DefinirDataMedicao(DateTime.MinValue)
        );

        // Assert
        exception.Message.ShouldBe("A data de medição é obrigatória.");
    }

    #endregion

    #region DefinirTipo

    [Fact]
    public void Deve_definir_tipo_valido()
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novoTipo = TipoMedicao.Umidade;

        // Act
        medicao.DefinirTipo(novoTipo);

        // Assert
        medicao.Tipo.ShouldBe(novoTipo);
    }

    [Fact]
    public void Nao_deve_definir_tipo_invalido()
    {
        // Arrange
        var medicao = CriarMedicaoValida();

        // Act
        var exception = Should.Throw<DomainException>(
            () => medicao.DefinirTipo((TipoMedicao)99)
        );

        // Assert
        exception.Message.ShouldBe("Tipo de medição inválido.");
    }

    #endregion

    #region DefinirValor

    [Fact]
    public void Deve_definir_valor_valido()
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novoValor = 32;

        // Act
        medicao.DefinirValor(novoValor);

        // Assert
        medicao.Valor.ShouldBe(novoValor);
    }

    [Fact]
    public void Deve_definir_valor_negativo_valido()
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novoValor = -5.5;
        var novoTipo = TipoMedicao.Temperatura;
        medicao.DefinirTipo(novoTipo);

        // Act
        medicao.DefinirValor(novoValor);

        // Assert
        medicao.Valor.ShouldBe(novoValor);
    }

    [Theory]
    [InlineData(TipoMedicao.Precipitacao)]
    [InlineData(TipoMedicao.Umidade)]
    public void Nao_deve_definir_valor_negativo_invalido(TipoMedicao novoTipo)
    {
        // Arrange
        var medicao = CriarMedicaoValida();
        var novoValor = -5;
        medicao.DefinirTipo(novoTipo);

        // Act
        var exception = Should.Throw<DomainException>(
            () => medicao.DefinirValor(novoValor)
        );

        // Assert
        exception.Message.ShouldBe("O valor da medição não pode ser negativa para esse tipo de medição.");
    }

    #endregion

    #region Helpers

    private static Medicao CriarMedicaoValida()
        => new(idTalhao, dataMedicao, tipo, valor);

    #endregion
}
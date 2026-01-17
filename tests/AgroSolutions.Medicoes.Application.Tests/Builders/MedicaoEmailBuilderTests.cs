using System.Globalization;
using AgroSolutions.Medicoes.Application.Builders;
using AgroSolutions.Medicoes.Domain.Enums;
using Moq;
using Shouldly;

namespace AgroSolutions.Medicoes.Application.Tests.Builders;

public class MedicaoEmailBuilderTests
{
    [Fact]
    public void Build_Deve_Gerar_Html_Com_Titulo_De_Temperatura()
    {
        // Arrange
        var tipo = TipoMedicao.Temperatura;
        double valor = 38.5;
        int horas = 6;

        // Act
        var html = MedicaoEmailBuilder.Build(
            tipoMedicao: tipo,
            valorMedio: valor,
            horasAnalisadas: horas,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()            
        );

        // Assert
        html.ShouldContain("Alerta de altas temperaturas.");
        html.ShouldContain("°C");
        html.ShouldContain(valor.ToString("F2", CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Build_Deve_Gerar_Html_Com_Titulo_De_Umidade()
    {
        // Arrange
        var tipo = TipoMedicao.Umidade;
        double valor = 10;
        int horas = 6;

        // Act
        var html = MedicaoEmailBuilder.Build(
            tipoMedicao: tipo,
            valorMedio: valor,
            horasAnalisadas: horas,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain("Alerta de seca.");
        html.ShouldContain("%");
        html.ShouldContain(valor.ToString("F2", CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Build_Deve_Gerar_Html_Com_Titulo_De_Precipitacao()
    {
        // Arrange
        var tipo = TipoMedicao.Precipitacao;
        double valor = 90;
        int horas = 6;

        // Act
        var html = MedicaoEmailBuilder.Build(
            tipoMedicao: tipo,
            valorMedio: valor,
            horasAnalisadas: horas,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain("Alerta de enchente.");
        html.ShouldContain("mm");
        html.ShouldContain(valor.ToString("F2", CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Build_Deve_Inserir_Valores_Formatados_No_Html()
    {
        // Act
        var html = MedicaoEmailBuilder.Build(
            TipoMedicao.Temperatura,
            valorMedio: 38.5678,
            horasAnalisadas: 6,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain("38.57");
    }

    [Fact]
    public void Build_Deve_Conter_Descricao_Correta_Para_Temperatura()
    {
        // Act
        var html = MedicaoEmailBuilder.Build(
            TipoMedicao.Temperatura,
            valorMedio: 40,
            horasAnalisadas: 3,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain(
            "A temperatura média registrada pelos sensores está acima do limite esperado."
        );
    }

    [Fact]
    public void Build_Deve_Conter_Descricao_Correta_Para_Umidade()
    {
        // Act
        var html = MedicaoEmailBuilder.Build(
            TipoMedicao.Umidade,
            valorMedio: 60,
            horasAnalisadas: 3,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain(
            "A média da umidade registrada pelos sensores está abaixo do limite esperado."
        );
    }

    [Fact]
    public void Build_Deve_Conter_Descricao_Correta_Para_Precipitacao()
    {
        // Act
        var html = MedicaoEmailBuilder.Build(
            TipoMedicao.Precipitacao,
            valorMedio: 200,
            horasAnalisadas: 5,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldContain(
            "A precipitação média registrada pelos sensores está acima do limite esperado."
        );
    }

    [Fact]
    public void Build_DeveConterEstruturaBasicaDeHtml()
    {
        // Act
        var html = MedicaoEmailBuilder.Build(
            TipoMedicao.Umidade,
            valorMedio: 90,
            horasAnalisadas: 8,
            nomeTalhao: It.IsAny<string>(),
            nomePropriedade: It.IsAny<string>()  
        );

        // Assert
        html.ShouldStartWith("<!DOCTYPE html>");
        html.ShouldContain("<html");
        html.ShouldContain("<body>");
        html.ShouldContain("</html>");
    }
}

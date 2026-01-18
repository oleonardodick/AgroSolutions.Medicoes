using System.Globalization;
using System.Text;
using AgroSolutions.Medicoes.Domain.Enums;

namespace AgroSolutions.Medicoes.Application.Builders;

public class MedicaoEmailBuilder
{
    public static string Build(
        TipoMedicao tipoMedicao, 
        double valorMedio, 
        int horasAnalisadas,
        string nomeTalhao,
        string nomePropriedade,
        double limiteEsperado
    )
    {
        string titulo = GetTitulo(tipoMedicao);
        string unidade = GetUnidade(tipoMedicao);
        string descricao = GetDescricao(tipoMedicao);

        var valorFormatado = valorMedio.ToString("F2", CultureInfo.InvariantCulture);
        var limiteFormatado = limiteEsperado.ToString("F2", CultureInfo.InvariantCulture);
        
        var sb = new StringBuilder();

        sb.Append($@"
            <!DOCTYPE html>
            <html lang='pt-BR'>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{
                            font-family: Arial, Helvetica, sans-serif;
                            background-color: #f4f6f8;
                            padding: 20px;
                        }}
                        .container {{
                            max-width: 600px;
                            background-color: #ffffff;
                            margin: auto;
                            padding: 20px;
                            border-radius: 6px;
                            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
                        }}
                        .header {{
                            color: #b91c1c;
                            font-size: 22px;
                            margin-bottom: 10px;
                        }}
                        .content {{
                            font-size: 14px;
                            color: #333333;
                            line-height: 1.6;
                        }}
                        .highlight {{
                            background-color: #fee2e2;
                            padding: 10px;
                            border-left: 4px solid #dc2626;
                            margin: 15px 0;
                        }}
                        .footer {{
                            font-size: 12px;
                            color: #666666;
                            margin-top: 20px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            {titulo}
                        </div>
                        <div class='content'>
                            <p>{descricao}</p>

                            <div class='highlight'>
                                <p><strong>Propriedade:</strong> {nomePropriedade}</p>
                                <p><strong>Talhão:</strong> {nomeTalhao}</p>
                                <p><strong>Média das últimas {horasAnalisadas} horas:</strong> {valorFormatado} {unidade}</p>
                                <p><strong>Limite esperado:</strong> {limiteFormatado} {unidade}</p>
                            </div>

                            <p>Recomendado avaliar as condições do local e tomar as medidas necessárias.</p>

                            <div class='footer'>
                                Este é um e-mail automático, por favor não responda.
                            </div>
                        </div>
                    </div>
                </body>
            </html>
        ");

        return sb.ToString().Trim();
    }

    private static string GetUnidade(TipoMedicao tipo)
    {
        return tipo switch
        {
            TipoMedicao.Temperatura => "°C",
            TipoMedicao.Umidade => "%",
            TipoMedicao.Precipitacao => "mm",
            _ => string.Empty
        };
    }

    private static string GetTitulo(TipoMedicao tipo)
    {
        return tipo switch
        {
            TipoMedicao.Temperatura => "Alerta de altas temperaturas.",
            TipoMedicao.Umidade => "Alerta de seca.",
            TipoMedicao.Precipitacao => "Alerta de enchente.",
            _ => string.Empty
        };
    }

    private static string GetDescricao(TipoMedicao tipo)
    {
        return tipo switch
        {
            TipoMedicao.Temperatura => 
                "A temperatura média registrada pelos sensores está acima do limite esperado.",
            TipoMedicao.Umidade => 
                "A média da umidade registrada pelos sensores está abaixo do limite esperado.",
            TipoMedicao.Precipitacao =>
                "A precipitação média registrada pelos sensores está acima do limite esperado.",
            _ => string.Empty
        };
    }
}

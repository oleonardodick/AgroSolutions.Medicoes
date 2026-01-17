namespace AgroSolutions.Medicoes.Application.DTOs;

public class MedicaoMediaDTO
{
    public Guid IdTalhao { get; set; }
    public string NomeTalhao { get; init; } = string.Empty;
    public string NomePropriedade { get; init; } = string.Empty;
    public string EmailProdutor { get; init; } = string.Empty;
    public double MediaValor { get; init; }
}

namespace AgroSolutions.Medicoes.Application.Services;

public class EmailSettings
{
    public string Host { get; set; } = default!;
    public int Port { get; set; }
    public string From { get; set; } = default!;
    public bool UseSsl { get; set; }
}

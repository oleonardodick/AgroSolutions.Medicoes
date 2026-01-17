namespace AgroSolutions.Medicoes.Application.Interfaces.Services;

public interface IEmailService
{
    Task EnviarEmailAsync(string para, string assunto, string corpo);
}

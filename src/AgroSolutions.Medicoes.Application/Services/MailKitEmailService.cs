using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace AgroSolutions.Medicoes.Application.Services;

public class MailKitEmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public MailKitEmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;    
    }

    public async Task EnviarEmailAsync(string para, string assunto, string corpoHtml)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Agro Solutions", _settings.From));
        message.To.Add(MailboxAddress.Parse(para));
        message.Subject = assunto;

        message.Body = new BodyBuilder
        {
            HtmlBody = corpoHtml
        }.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(
            _settings.Host,
            _settings.Port,
            _settings.UseSsl
                ? SecureSocketOptions.StartTls
                : SecureSocketOptions.None
        );

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}

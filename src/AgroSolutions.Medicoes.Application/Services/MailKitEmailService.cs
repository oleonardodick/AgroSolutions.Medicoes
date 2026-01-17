using AgroSolutions.Medicoes.Application.Interfaces.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace AgroSolutions.Medicoes.Application.Services;

public class MailKitEmailService(IConfiguration _configuration) : IEmailService
{
    public async Task EnviarEmailAsync(string para, string assunto, string corpoHtml)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("App", _configuration["SMTP_FROM"]));
        message.To.Add(MailboxAddress.Parse(para));
        message.Subject = assunto;

        message.Body = new TextPart("html")
        {
            Text = corpoHtml
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(
            _configuration["SMTP_HOST"],
            int.Parse(_configuration["SMTP_PORT"]!),
            false
        );

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}

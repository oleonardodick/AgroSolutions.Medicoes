namespace AgroSolutions.Medicoes.Infrastructure.Messaging;

public sealed class RabbitMqSettings
{
    public string Host { get; init; } = default!;
    public int Port { get; init; }
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string VirtualHost { get; init; } = "/";
}

using AgroSolutions.Medicoes.Application;
using AgroSolutions.Medicoes.Application.Services;
using AgroSolutions.Medicoes.Infrastructure;
using AgroSolutions.Medicoes.Worker;
using AgroSolutions.Medicoes.Worker.Consumers;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("Email"));
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<SensorDataConsumer>();
    x.AddConsumer<PropriedadeDataConsumer>();
    x.AddConsumer<TalhaoDataConsumer>();
    x.AddConsumer<ProdutorDataConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("admin");
            h.Password("admin123");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var host = builder.Build();
host.Run();

using Frame.Demo.Stack.TemperatureProbe;
using MassTransit;
using Frame.Demo.Stack.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.AddContainerLogging();
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
    {
        busFactoryConfigurator.Host(builder.Configuration.GetValue<string>("RabbitMqHostname"), hostConfigurator =>
        {
            hostConfigurator.Username(builder.Configuration.GetValue<string>("RabbitMqUsername"));
            hostConfigurator.Password(builder.Configuration.GetValue<string>("RabbitMqPassword"));
        });
    });
});
var host = builder.Build();
host.Run();
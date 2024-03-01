using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Frame.Demo.Stack.Messaging;

public static class Extensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection self, IConfiguration configuration)
    {
        self.AddMassTransit(busConfigurator =>
        {
            // busConfigurator.AddConsumer<TemperatureSampleConsumer>();
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                busFactoryConfigurator.Host(configuration.GetValue<string>("RabbitMqHostname"), hostConfigurator =>
                {
                    hostConfigurator.Username(configuration.GetValue<string>("RabbitMqUsername"));
                    hostConfigurator.Password(configuration.GetValue<string>("RabbitMqPassword"));
                });
                
                // busFactoryConfigurator.ReceiveEndpoint("test123", endpoint =>
                // {
                //     endpoint.ConfigureConsumer<TemperatureSampleConsumer>(context);
                // });
            });
        });
        return self;
    }
}
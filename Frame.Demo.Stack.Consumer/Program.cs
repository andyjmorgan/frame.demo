using Frame.Demo.Stack.Consumer.Consumers;
using Frame.Demo.Stack.DBContext;
using Frame.Demo.Stack.DBContext.Extensions;
using Frame.Demo.Stack.Logging;
using Frame.Demo.Stack.Messaging;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Frame.Demo.Stack.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.AddContainerLogging();
            builder.Services.AddFrameDbContext(builder.Configuration);
            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.AddConsumer<TemperatureSampleConsumer, TemperatureSampleConsumerDefinition>();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host(builder.Configuration.GetValue<string>("RabbitMqHostname"), hostConfigurator =>
                    {
                        hostConfigurator.Username(builder.Configuration.GetValue<string>("RabbitMqUsername"));
                        hostConfigurator.Password(builder.Configuration.GetValue<string>("RabbitMqPassword"));
                    });

                    busFactoryConfigurator.ConfigureEndpoints(context);
                });


            });

            builder.Services.AddHostedService<Worker>();
            var host = builder.Build();

            // Build Entity Framework Migrations.
            var scope = host.Services.CreateScope();
            var frameContext = scope.ServiceProvider.GetRequiredService<FrameContext>();
            if (frameContext is not null)
            {
                if (frameContext.Database.GetPendingMigrations().Any())
                {
                    frameContext.Database.Migrate();
                }
            }
            host.Run();
        }
    }
}
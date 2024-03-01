using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace Frame.Demo.Stack.Logging
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddContainerLogging(this IHostApplicationBuilder hostApplicationBuilder)
        {
            return hostApplicationBuilder.Services.AddSerilog((context, loggerConfig) =>
            {
                loggerConfig.ReadFrom.Configuration(hostApplicationBuilder.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .Enrich.FromMassTransit()
                .Enrich.WithProperty("ApplicationName", hostApplicationBuilder.Environment.ApplicationName)
                .Enrich.WithExceptionDetails()
                .WriteTo.Console()
                .WriteTo.Seq(hostApplicationBuilder.Configuration.GetValue<string>("SeqAddress", "")!);
            });
        }
    }
}

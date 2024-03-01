using Frame.Demo.Stack.Messaging.Messages.Queues;
using MassTransit;

namespace Frame.Demo.Stack.TemperatureProbe;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory iServiceScopeFactory;
    public Worker(ILogger<Worker> logger, IServiceScopeFactory iServiceScopeFactory)
    {
        _logger = logger;
        this.iServiceScopeFactory = iServiceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        }
        Random random = new Random();
        using var scope = this.iServiceScopeFactory.CreateScope();
        var iPublishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>();
        if (iPublishEndpoint is null)
        {
            throw new Exception("Could not retrieve publisher endpoint from service scope.");
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            var msg = new TemperatureSampleMessage()
            {
                Date = DateOnly.FromDateTime(DateTime.UtcNow),
                Summary = "Dublin",
                TemperatureC = random.Next(20, 35)
            };
            _logger.LogInformation("sending probe with {Temperature}", msg.TemperatureC);
            await iPublishEndpoint.Publish<TemperatureSampleMessage>(msg);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
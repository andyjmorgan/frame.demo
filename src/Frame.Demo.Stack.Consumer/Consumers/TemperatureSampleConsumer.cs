using Frame.Demo.Stack.DBContext;
using Frame.Demo.Stack.Messaging.Messages.Queues;
using MassTransit;

namespace Frame.Demo.Stack.Consumer.Consumers;
public class TemperatureSampleConsumer(ILogger<TemperatureSampleConsumer> logger, FrameContext dbContext) : IConsumer<TemperatureSampleMessage>
{
    public Task Consume(ConsumeContext<TemperatureSampleMessage> context)
    {
        logger.LogInformation("Received Temperature Sample: {temperature}", context.Message.TemperatureC);
        dbContext.TemperatureSamples.Add(new DBContext.Classes.TemperatureSample
        {
            Location = context.Message.Summary,
            Temperature = context.Message.TemperatureC,
            Time = DateTime.UtcNow
        });
        dbContext.SaveChanges();

        return Task.CompletedTask;
    }
}

public class TemperatureSampleConsumerDefinition : ConsumerDefinition<TemperatureSampleConsumer>
{
    public TemperatureSampleConsumerDefinition()
    {
    }
}
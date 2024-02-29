using MassTransit;

namespace Frame.Demo.Stack.Messaging.Messages.Queues;

[ExcludeFromTopology]
public record TemperatureSampleMessage : IConsumer
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; init; }
    public string? Summary { get; init; }
}
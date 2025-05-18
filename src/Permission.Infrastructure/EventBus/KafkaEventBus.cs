using KafkaFlow;
using Permission.Application.Abstraction.EventBus;
using Permission.Domain.Events;

namespace Permission.Infrastructure.EventBus;

public class KafkaEventBus : IEventBus
{    
    private readonly IMessageProducer<OperationProducer> _producer;

    public KafkaEventBus(IMessageProducer<OperationProducer> producer)
    {
        _producer = producer;
    }

    public async Task PublishAsync<T>(T message)
    {
        await _producer.ProduceAsync(Guid.NewGuid().ToString(), message);
    }
}
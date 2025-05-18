namespace Permission.Application.Abstraction.EventBus;

public interface IEventBus
{
    Task PublishAsync<T>(T message);
}
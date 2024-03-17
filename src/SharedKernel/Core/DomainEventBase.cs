using Mediator;

namespace SharedKernel.Core;

public abstract class DomainEventBase(string data) : INotification
{
    public DateTime OccurredUtc { get; private set; } = DateTime.UtcNow;
    public string Data { get; init; } = data;
}
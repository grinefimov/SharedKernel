using Mediator;

namespace SharedKernel;

public abstract class DomainEventBase : INotification
{
    public DateTime OccurredUtc { get; protected set; } = DateTime.UtcNow;
}
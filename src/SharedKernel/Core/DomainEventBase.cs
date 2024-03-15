using Mediator;

namespace SharedKernel.Core;

public abstract record DomainEventBase : INotification
{
    public DateTime OccurredUtc { get; private set; } = DateTime.UtcNow;
}
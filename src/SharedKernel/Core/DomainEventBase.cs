using Mediator;

namespace SharedKernel.Core;

public abstract class DomainEventBase(DateTime occurredUtc) : INotification
{
    public DateTime OccurredUtc { get; set; } = occurredUtc;
    // TODO: Consider moving to Infrastructure
    public abstract string Data { get; set; }
}
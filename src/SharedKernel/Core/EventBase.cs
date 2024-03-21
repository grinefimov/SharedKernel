using Mediator;

namespace SharedKernel.Core;

public abstract class EventBase(DateTime occurredUtc) : INotification
{
    public DateTime OccurredUtc { get; set; } = occurredUtc;
    // TODO: Consider moving to Infrastructure
    public abstract string? Data { get; set; }
}
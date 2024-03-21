using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SharedKernel.Core;

public abstract class HasEventsBase
{
    private readonly List<EventBase> _domainEvents = [];
    [JsonIgnore]
    [NotMapped]
    public IEnumerable<EventBase> DomainEvents => [.. _domainEvents];
    protected void RegisterDomainEvent(EventBase domainEvent)
    {
        domainEvent.OccurredUtc = DateTime.UtcNow;
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
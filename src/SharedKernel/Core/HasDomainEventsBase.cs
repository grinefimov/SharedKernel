using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SharedKernel.Core;

public abstract class HasDomainEventsBase
{
    private readonly List<DomainEventBase> _domainEvents = [];
    [JsonIgnore]
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => [.. _domainEvents];
    protected void RegisterDomainEvent(DomainEventBase domainEvent)
    {
        domainEvent.OccurredUtc = DateTime.UtcNow;
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
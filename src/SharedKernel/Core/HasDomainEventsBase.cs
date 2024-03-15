using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel.Core;

public abstract class HasDomainEventsBase
{
    private readonly List<DomainEventBase> _domainEvents = [];
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => [.. _domainEvents];
    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
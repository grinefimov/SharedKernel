using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel;

public abstract class HasDomainEventsBase
{
    private readonly List<DomainEventBase> _domainEvents = [];
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    protected void ClearDomainEvents() => _domainEvents.Clear();
}
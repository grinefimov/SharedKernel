namespace SharedKernel;

public abstract class EntityBase(int id) : EntityBase<int>(id);

public abstract class EntityBase<TId>(TId id) : HasDomainEventsBase
    where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; } = id;
}
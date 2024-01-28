namespace SharedKernel;

public abstract class EntityBase : EntityBase<int>;

public abstract class EntityBase<TId> : HasDomainEventsBase where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
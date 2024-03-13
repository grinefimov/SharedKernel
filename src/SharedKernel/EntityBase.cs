namespace SharedKernel;

public abstract class EntityBase(int id) : EntityBase<int>(id);

public abstract class EntityBase<TId>(TId id) : HasDomainEventsBase
    where TId : struct, IEquatable<TId>
{
    // TODO: Consider using strongly-typed IDs: https://github.com/andrewlock/StronglyTypedId
    public TId Id { get; set; } = id;
    // TODO: Reconsider time for Audit logging
    public DateTime? UpdatedUtc { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
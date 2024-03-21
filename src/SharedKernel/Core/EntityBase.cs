namespace SharedKernel.Core;

public abstract class EntityBase(int? id) : EntityBase<int>(id);

// TODO: Consider https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/Domain/Common/BaseAuditableEntity.cs
public abstract class EntityBase<TId>(TId? id) : HasEventsBase
    where TId : struct, IEquatable<TId>
{
    // TODO: Consider using strongly-typed IDs: https://github.com/andrewlock/StronglyTypedId
    public TId? Id { get; set; } = id;
    // TODO: Reconsider time for Audit logging
    public DateTime? UpdatedUtc { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
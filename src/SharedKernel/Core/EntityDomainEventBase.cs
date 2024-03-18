using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;

namespace SharedKernel.Core;

// TODO: Consider moving to Infrastructure
public abstract class EntityDomainEventBase<T, TId>(DateTime occurredUtc, T? entity)
    : DomainEventBase(occurredUtc) where T : EntityBase<TId> where TId : struct, IEquatable<TId>
{
    private string? _data = entity is null ? null : JsonSerializer.Serialize(entity);

    public override string? Data
    {
        get
        {
            if (entity is not null)
                return JsonSerializer.Serialize(entity,
                    new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
            return _data;
        }
        set => _data = value;
    }

    protected T? GetEntity()
    {
        if (entity is not null) return entity;
        if (string.IsNullOrWhiteSpace(Data)) return null;
        entity = JsonSerializer.Deserialize<T>(Data);
        Guard.Against.Null(entity, nameof(entity), "Entity deserialization failed.");
        return entity;
    }
}
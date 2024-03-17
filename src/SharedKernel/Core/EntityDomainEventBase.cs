using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharedKernel.Core;

// TODO: Consider moving to Infrastructure
public abstract class EntityDomainEventBase<T>(DateTime occurredUtc, T entity) : DomainEventBase(occurredUtc)
{
    private string _data = JsonSerializer.Serialize(entity);
    protected T? Entity = entity;

    public override string Data
    {
        get => Entity is null
            ? _data
            : JsonSerializer.Serialize(Entity,
                new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });
        set => _data = value;
    }

    protected T? GetEntity()
    {
        if (Entity is not null) return Entity;
        return Entity = JsonSerializer.Deserialize<T>(Data);
    }
}
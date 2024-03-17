using System.Text.Json;

namespace SharedKernel.Core;

public abstract class EntityDomainEventBase<T>(T entity) : DomainEventBase(JsonSerializer.Serialize(entity))
{
    private T? _entity = entity;

    protected T? Entity
    {
        get
        {
            if (_entity is not null) return _entity;
            _entity = JsonSerializer.Deserialize<T>(Data);
            return _entity;
        }
        init => _entity = value;
    }
}
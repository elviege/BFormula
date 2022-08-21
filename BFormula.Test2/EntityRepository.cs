using System.Collections.Concurrent;

namespace BFormula.Test2;

public class EntityRepository : IEntityRepository
{
    private readonly ConcurrentDictionary<Guid, Entity> _data = new();

    public bool Set(Entity? entity)
    {
        if (entity is null) return false;
        
        _data[entity.Id] = entity;
        return true;
    }

    public Entity? Get(Guid id)
    {
        return _data.ContainsKey(id) ? _data[id] : null;
    }
}
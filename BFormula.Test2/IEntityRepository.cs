namespace BFormula.Test2;

public interface IEntityRepository
{
    bool Set(Entity? entity);
    Entity? Get(Guid id);
}
namespace TRPO.Data;

public interface IGenericRepository<TEntity> where TEntity : class, IEntity
{
    void Create(TEntity entity);
    IEnumerable<TEntity> GetEntities();
    IEnumerable<TEntity> GetEntities(Func<TEntity, bool> func);
    TEntity GetEntity(int id);
    void Remove(int id);
    void Update(int id, TEntity entity);
}

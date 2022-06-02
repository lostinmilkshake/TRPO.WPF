using Microsoft.EntityFrameworkCore;

namespace TRPO.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    protected DbContext _dbContext;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual TEntity GetEntity(int id)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }

    public virtual IEnumerable<TEntity> GetEntities()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public virtual IEnumerable<TEntity> GetEntities(Func<TEntity, bool> func)
    {
        return _dbSet.AsNoTracking().Where(func);
    }

    public virtual void Create(TEntity entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public virtual void Update(int id, TEntity entity)
    {
        _dbContext.ChangeTracker.Clear();

        entity.Id = id;

        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }

    public virtual void Remove(int id)
    {
        var entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }
}

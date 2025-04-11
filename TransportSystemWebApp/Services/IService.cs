using System.Linq.Expressions;

namespace TransportSystemWebApp.Services;

public interface IService<TEntity>
{
    Task AddAsync(TEntity value);
    Task AddRangeAsync(IEnumerable<TEntity> values);
    Task UpdateAsync(TEntity newEntity);
    Task DeleteAsync(TEntity value);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IQueryable<TEntity>> GetAllAsync();
}

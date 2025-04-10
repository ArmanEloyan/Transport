using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystemWebApp.Services
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity value);
        Task AddRangeAsync(IEnumerable<TEntity> values);
        Task UpdateAsync(TEntity newEntity);
        Task DeleteAsync(TEntity value);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

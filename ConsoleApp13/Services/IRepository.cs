using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal interface IRepository<TEntity,TKey>
    {
        Task AddAsync(TEntity value);
        Task UpdateAsync(TEntity newEntity);
        Task DeleteAsync(TKey key);
        Task<TEntity> GetAsync(TKey key);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

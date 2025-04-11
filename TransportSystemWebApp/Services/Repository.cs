using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportSystemWebApp;
using TransportSystemWebApp.Entities;

namespace TransportSystemWebApp.Services
{
    public class Repository<TEntity,TDbContext> : IRepository<TEntity>
    where TEntity : class 
    where TDbContext : DbContext
    {
        private readonly TDbContext _dataContext;

        public Repository(TDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(TEntity value)
        {
            await _dataContext.Set<TEntity>().AddAsync(value);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> values)
        {
            await _dataContext.Set<TEntity>().AddRangeAsync(values);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity value)
        {
            _dataContext.Set<TEntity>().Remove(value);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) 
            => await ApplyIncludes(_dataContext.Set<TEntity>().AsNoTracking()).FirstOrDefaultAsync(predicate);

        public Task<IQueryable<TEntity>> GetAllAsync() => Task.FromResult(ApplyIncludes(_dataContext.Set<TEntity>().AsNoTracking()).AsQueryable());

        public async Task UpdateAsync(TEntity newEntity)
        {
            _dataContext.Set<TEntity>().Update(newEntity);
            await _dataContext.SaveChangesAsync();
        }

        private IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query)
        {
            if (typeof(TEntity) == typeof(Way))
            {
                return query
                    .Include(e => ((Way)(object)e).CityFrom)
                    .Include(e => ((Way)(object)e).CityTo);
            }
            else if (typeof(TEntity) == typeof(Order))
            {
                return query
                    .Include(e => ((Order)(object)e).WayObj)
                        .ThenInclude(w => w.CityFrom)
                    .Include(e => ((Order)(object)e).WayObj)
                        .ThenInclude(w => w.CityTo)
                    .Include(e => ((Order)(object)e).CarObj);
            }
            else if (typeof(TEntity) == typeof(Car))
            {
                return query
                    .Include(e => ((Car)(object)e).Type);
            }

            return query;
        }
    }
}

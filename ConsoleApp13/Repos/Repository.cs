using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.Models;

namespace ConsoleApp13.Repos
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity value)
        {
            if (value == null)
                throw new ArgumentNullException("Value cant be null");

            _dataContext.Set<TEntity>().Add(value);
            _dataContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> values)
        {
            if (values == null)
                throw new ArgumentNullException("Values cant be null");

            _dataContext.Set<TEntity>().AddRange(values);
            _dataContext.SaveChanges();
        }

        public void Delete(TEntity value)
        {
            _dataContext.Set<TEntity>().Remove(value);
            _dataContext.SaveChanges();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            TEntity entity = _dataContext.Set<TEntity>().FirstOrDefault(predicate);

            if (entity == null)
                throw new Exception("Cant find");

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ApplyIncludes(_dataContext.Set<TEntity>()).AsEnumerable();
        }

        public void Update(TEntity newEntity)
        {
            _dataContext.Set<TEntity>().Update(newEntity);
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

            return query;
        }
    }
}

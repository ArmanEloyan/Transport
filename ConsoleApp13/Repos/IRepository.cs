using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal interface IRepository<TEntity>
    {
        void Add(TEntity value);
        void AddRange(IEnumerable<TEntity> values);
        void Update(TEntity newEntity);
        void Delete(TEntity value);
        TEntity Get(Func<TEntity,bool> predicate);
        IEnumerable<TEntity> GetAll();
    }
}

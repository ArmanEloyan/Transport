using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal interface IRepository<T>
    {
        void Add(T value);
        void AddRange(IEnumerable<T> values);
        void Update(T oldEntity, T newEntity);
        void Delete(T value);
        T Get(Func<T, bool> func);
        IEnumerable<T> GetAll();
    }
}

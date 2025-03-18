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
        void Update(int id, T newEntity);
        void Delete(T value);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}

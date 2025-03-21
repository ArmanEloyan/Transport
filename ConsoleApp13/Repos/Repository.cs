﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Repos
{
    internal class Repository<T> : IRepository<T>
    {
        private List<T> _values = new List<T>();

        public void Add(T value)
        {
            _values.Add(value);
        }

        public void AddRange(IEnumerable<T> values)
        {
            _values.AddRange(values);
        }

        public void Delete(T value)
        {
            _values.Remove(value);
        }

        public T Get(int id)
        {

           throw new Exception($"Cant find!");
        }

        public IEnumerable<T> GetAll()
        {
            return _values;
        }

        public void Update(int id, T newEntity)
        {
            T oldEntity = Get(id);

            int index = _values.IndexOf(oldEntity);

            if (index == -1)
            {
                throw new Exception("Cant find!");
            }
            _values[index] = newEntity;
        }
    }
}

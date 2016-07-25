using System.Collections.Generic;
using System;

namespace Auspex.TripService.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(int key);
        T Remove(int key);
        void Update(T item);
    }
}
using System.Collections.Generic;

namespace Auspex.TripService.Repositories
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T Find(int key);
        T Remove(int key);
        void Update(T item);
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Auspex.TripService.Models;

namespace Auspex.TripService.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly TripServiceContext _context;

        public CarRepository(TripServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        
        }

        public void Add(Car item)
        {
            var latestCar = _context.Cars.OrderByDescending(c => c.Id).FirstOrDefault();
            if (latestCar == null)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = latestCar.Id + 1;   
            }
            _context.Cars.Add(item);
            _context.SaveChanges();            
        }

        public Car Find(int key)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == key);
        }

        public Car Remove(int key)
        {
            _context.Cars.Remove(Find(key));
            _context.SaveChanges();

            return null;
        }

        public void Update(Car item)
        {
            _context.Cars.Update(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
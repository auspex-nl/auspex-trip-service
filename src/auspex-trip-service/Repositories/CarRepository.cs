using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Auspex.TripService.Models;

namespace Auspex.TripService.Repositories
{
    public class CarRepository : ICarRepository
    {
        public CarRepository()
        {
        }

        public IEnumerable<Car> GetAll()
        {
            using (var db = new TripServiceContext())
            {
                return db.Cars.ToList();
            }            
        }

        public void Add(Car item)
        {
            using (var db = new TripServiceContext())
            {
                var latestCar = db.Cars.OrderByDescending(c => c.Id).FirstOrDefault();
                if (latestCar == null)
                {
                    item.Id = 1;
                }
                else
                {
                    item.Id = latestCar.Id + 1;   
                }
                db.Cars.Add(item);
                db.SaveChanges();
            }
        }

        public Car Find(int key)
        {
            using (var db = new TripServiceContext())
            {
                return db.Cars.FirstOrDefault(c => c.Id == key);
            }
        }

        public Car Remove(int key)
        {
            using (var db = new TripServiceContext())            
            {
                db.Cars.Remove(Find(key));
                db.SaveChanges();
            }
            return null;
        }

        public void Update(Car item)
        {
            using (var db = new TripServiceContext())
            {
                db.Cars.Update(item);
                db.SaveChanges();
            }
        }
    }
}
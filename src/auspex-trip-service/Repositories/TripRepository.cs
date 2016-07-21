using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Auspex.TripService.Models;

namespace Auspex.TripService.Repositories
{
    public class TripRepository : ITripRepository
    {
        private static ConcurrentDictionary<int, Trip> Trips = 
                    new ConcurrentDictionary<int, Trip>();

        public TripRepository()
        {
            Add(new Trip { Remarks = "Trip.Remarks1", Car = new Car { Make = "Car1.Make", Model= "Car1.Model"} });
        }

        public IEnumerable<Trip> GetAll()
        {
            return Trips.Values;
        }

        public void Add(Trip item)
        {
            item.Id = 1000;
            Trips[item.Id] = item;
        }

        public Trip Find(int key)
        {
            Trip item;
            Trips.TryGetValue(key, out item);
            return item;
        }

        public Trip Remove(int key)
        {
            Trip item;
            Trips.TryGetValue(key, out item);
            Trips.TryRemove(key, out item);
            return item;
        }

        public void Update(Trip item)
        {
            Trips[item.Id] = item;
        }
    }
}
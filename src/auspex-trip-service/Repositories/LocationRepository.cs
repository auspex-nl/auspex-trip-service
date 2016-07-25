using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Auspex.TripService.Models;

namespace Auspex.TripService.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private static ConcurrentDictionary<int, Location> Locations = 
                    new ConcurrentDictionary<int, Location>();

        public LocationRepository()
        {
            Add(new Location { Name = "Location1", Address = "Address1" });
        }

        public IEnumerable<Location> GetAll()
        {
            return Locations.Values;
        }

        public void Add(Location item)
        {
            item.Id = 1000;
            Locations[item.Id] = item;
        }

        public Location Find(int key)
        {
            Location item;
            Locations.TryGetValue(key, out item);
            return item;
        }

        public Location Remove(int key)
        {
            Location item;
            Locations.TryGetValue(key, out item);
            Locations.TryRemove(key, out item);
            return item;
        }

        public void Update(Location item)
        {
            Locations[item.Id] = item;
        }

        public void Dispose()
        {

        }
    }
}
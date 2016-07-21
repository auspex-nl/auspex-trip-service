using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Auspex.TripService.Models;
using Auspex.TripService.Repositories;

namespace Auspex.TripService.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        public LocationController(ILocationRepository locations)
        {
            this.Locations = locations;
        }
        public ILocationRepository Locations { get; set; }

        public IEnumerable<Location> GetAll()
        {
            return this.Locations.GetAll();
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult GetById(int id)
        {
            var item = this.Locations.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
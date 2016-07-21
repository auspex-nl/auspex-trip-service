using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Auspex.TripService.Models;
using Auspex.TripService.Repositories;

namespace Auspex.TripService.Controllers
{
    [Route("api/[controller]")]
    public class TripController : Controller
    {
        public TripController(ITripRepository trips)
        {
            this.Trips = trips;
        }
        public ITripRepository Trips { get; set; }

        public IEnumerable<Trip> GetAll()
        {
            return this.Trips.GetAll();
        }

        [HttpGet("{id}", Name = "GetTrip")]
        public IActionResult GetById(int id)
        {
            var item = this.Trips.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
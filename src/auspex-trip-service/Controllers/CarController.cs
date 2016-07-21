using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Auspex.TripService.Models;
using Auspex.TripService.Repositories;

namespace Auspex.TripService.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        public CarController(ICarRepository cars)
        {
            this.Cars = cars;
        }
        public ICarRepository Cars { get; set; }

        public IEnumerable<Car> GetAll()
        {
            return this.Cars.GetAll();
        }

        [HttpGet("{id}", Name = "GetCar")]
        public IActionResult GetById(int id)
        {
            var item = this.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Car item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Cars.Add(item);
            return CreatedAtRoute("GetCar", new { id = item.Id }, item);
        }
    }
}
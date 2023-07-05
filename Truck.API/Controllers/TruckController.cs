using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Truck.API.Entities;
using Truck.API.Persistence;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly TruckEventsDbContext _context;

        public TruckController(TruckEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var truckEvents = _context.TruckEvents.Where(t => !t.isDeleted).ToList();
            return Ok(truckEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var truckEvent = _context.TruckEvents.SingleOrDefault(t => t.Id == id);

            if(truckEvent == null)
            {
                return NotFound();
            }

            return Ok(truckEvent);
        }

        [HttpPost]
        public IActionResult Post(TruckEvent truckEvent)
        {
            _context.TruckEvents.Add(truckEvent);

            return CreatedAtAction(nameof(GetById), new { id = truckEvent.Id }, truckEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TruckEvent input)
        {
            var truckEvent = _context.TruckEvents.SingleOrDefault(t => t.Id == id);

            if (truckEvent == null)
            {
                return NotFound();
            }

            truckEvent.Update(input.Model, input.Brand, input.ManafactureYear, input.ModelYear);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            var truckEvent = _context.TruckEvents.SingleOrDefault(t => t.Id == id);

            if (truckEvent == null)
            {
                return NotFound();
            }

            truckEvent.Delete();

            return NoContent();
        }

    }
}

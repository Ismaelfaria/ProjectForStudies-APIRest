
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoParaEstudo.Entity;
using ProjetoParaEstudo.Persistence;

namespace ProjetoParaEstudo.Controllers
{
    [Route("api/dev-event")]
    [ApiController]
    public class DevEventController : ControllerBase
    {

        private readonly DevEventDbContext _context;

        public DevEventController(DevEventDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvent = _context.DevEvent.Where(d => !d.IsDeleted).ToList();

            return Ok(devEvent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvent.SingleOrDefault(d => d.Id == id);

            if(devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Create(DevEvent devEvent)
        {
            _context.DevEvent.Add(devEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input)
        {
            var devEvent = _context.DevEvent.SingleOrDefault(d => d.Id == id);

            if(devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);
            _context.DevEvent.Update(devEvent);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleted(Guid id)
        {
            var devEvent = _context.DevEvent.SingleOrDefault(d => d.Id == id);

            if(DevEvent == null)
            {
                return NotFound();
            }

            devEvent.Deleted();
            _context.SaveChanges();

            return NoContent();
        }


    }
}

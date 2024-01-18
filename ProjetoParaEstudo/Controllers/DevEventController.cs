using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var devEvents = _context.devEvent.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.devEvent.SingleOrDefault(d => d.Id == id);

            if(devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvents)
        {
            _context.devEvent.Add(devEvents);

            return CreatedAtAction(nameof(GetById), new { id = devEvents.Id }, devEvents);
        }

    }
}


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
            var devEvent = _context.DevEvent.Where(de => !de.IsDeleted).ToList();
            return Ok(devEvent);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _context.DevEvent.SingleOrDefault(de => de.Id == id);

            if(devEvent == null)
            {
                return NotFound();
            }

            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvent.Add(devEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

    }
}

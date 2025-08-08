using Infra.Data;
using Infra.Domain.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infra.Controllers
{
    [Route("api/peoples")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeopleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peoples = await _context.Peoples.ToListAsync();
            return Ok(peoples);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] People people)
        {
            await _context.Peoples.AddAsync(people);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = people.Id }, people);
        }
    }
}

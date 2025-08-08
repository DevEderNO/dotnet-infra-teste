using Infra.Data;
using Infra.Domain.Peaple;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infra.Controllers
{
    [Route("api/peaples")]
    [ApiController]
    public class PeapleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeapleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peaples = await _context.Peaples.ToListAsync();
            return Ok(peaples);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Peaple peaple)
        {
            await _context.Peaples.AddAsync(peaple);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = peaple.Id }, peaple);
        }
    }
}

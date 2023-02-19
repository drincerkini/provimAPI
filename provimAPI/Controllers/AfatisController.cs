using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using provimAPI.Data;
using provimAPI.Models;

namespace provimAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfatisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AfatisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Afatis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Afati>>> GetAfatet()
        {
            return await _context.Afatet.ToListAsync();
        }

        // GET: api/Afatis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Afati>> GetAfati(int id)
        {
            var afati = await _context.Afatet.FindAsync(id);

            if (afati == null)
            {
                return NotFound();
            }

            return afati;
        }

        // PUT: api/Afatis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfati(int id, Afati afati)
        {
            if (id != afati.ID)
            {
                return BadRequest();
            }

            _context.Entry(afati).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfatiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Afatis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Afati>> PostAfati(Afati afati)
        {
            _context.Afatet.Add(afati);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAfati", new { id = afati.ID }, afati);
        }

        // DELETE: api/Afatis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAfati(int id)
        {
            var afati = await _context.Afatet.FindAsync(id);
            if (afati == null)
            {
                return NotFound();
            }

            _context.Afatet.Remove(afati);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AfatiExists(int id)
        {
            return _context.Afatet.Any(e => e.ID == id);
        }
    }
}

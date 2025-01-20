using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cw12_git.Data;
using Cw12_git.Model;

namespace Cw12_git.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezerwacjasController : ControllerBase
    {
        private readonly Cw12_gitContext _context;

        public RezerwacjasController(Cw12_gitContext context)
        {
            _context = context;
        }

        // GET: api/Rezerwacjas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rezerwacja>>> GetRezerwacja()
        {
            return await _context.Rezerwacja.ToListAsync();
        }

        // GET: api/Rezerwacjas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rezerwacja>> GetRezerwacja(int id)
        {
            var rezerwacja = await _context.Rezerwacja.FindAsync(id);

            if (rezerwacja == null)
            {
                return NotFound();
            }

            return rezerwacja;
        }

        // PUT: api/Rezerwacjas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRezerwacja(int id, Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id)
            {
                return BadRequest();
            }

            _context.Entry(rezerwacja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezerwacjaExists(id))
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

        // POST: api/Rezerwacjas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rezerwacja>> PostRezerwacja(Rezerwacja rezerwacja)
        {
            _context.Rezerwacja.Add(rezerwacja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRezerwacja", new { id = rezerwacja.Id }, rezerwacja);
        }

        // DELETE: api/Rezerwacjas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRezerwacja(int id)
        {
            var rezerwacja = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            _context.Rezerwacja.Remove(rezerwacja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.Id == id);
        }
    }
}

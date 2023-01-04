using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidencialApp;
using ResidencialApp.Entidades;

namespace ResidencialApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidencialsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ResidencialsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Residencials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residencial>>> GetResidencial()
        {
            return await _context.Residencial.ToListAsync();
        }

        // GET: api/Residencials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Residencial>> GetResidencial(int id)
        {
            var residencial = await _context.Residencial.FindAsync(id);

            if (residencial == null)
            {
                return NotFound();
            }

            return residencial;
        }

        // PUT: api/Residencials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidencial(int id, Residencial residencial)
        {
            if (id != residencial.Id)
            {
                return BadRequest();
            }

            _context.Entry(residencial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidencialExists(id))
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

        // POST: api/Residencials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Residencial>> PostResidencial(Residencial residencial)
        {
            _context.Residencial.Add(residencial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidencial", new { id = residencial.Id }, residencial);
        }

        // DELETE: api/Residencials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidencial(int id)
        {
            var residencial = await _context.Residencial.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }

            _context.Residencial.Remove(residencial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidencialExists(int id)
        {
            return _context.Residencial.Any(e => e.Id == id);
        }
    }
}

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
    public class VisitantesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public VisitantesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Visitantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitantes>>> GetVisitantes()
        {
            await Task.Delay(5000);
            return await _context.Visitantes.ToListAsync();
        }

        // GET: api/Visitantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitantes>> GetVisitantes(int id)
        {
            await Task.Delay(5000);
            var visitantes = await _context.Visitantes.FindAsync(id);

            if (visitantes == null)
            {
                return NotFound();
            }

            return visitantes;
        }

        // PUT: api/Visitantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitantes(int id, Visitantes visitantes)
        {
            if (id != visitantes.Id)
            {
                return BadRequest();
            }

            _context.Entry(visitantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitantesExists(id))
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

        // POST: api/Visitantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitantes>> PostVisitantes(Visitantes visitantes)
        {
            _context.Visitantes.Add(visitantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitantes", new { id = visitantes.Id }, visitantes);
        }

        // DELETE: api/Visitantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitantes(int id)
        {
            var visitantes = await _context.Visitantes.FindAsync(id);
            if (visitantes == null)
            {
                return NotFound();
            }

            _context.Visitantes.Remove(visitantes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitantesExists(int id)
        {
            return _context.Visitantes.Any(e => e.Id == id);
        }
    }
}

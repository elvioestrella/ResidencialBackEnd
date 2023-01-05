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
    public class DirectoriosController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public DirectoriosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Directorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Directorio>>> GetDirectorio()
        {
            await Task.Delay(5000);
            return await _context.Directorio.ToListAsync();
        }

        // GET: api/Directorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Directorio>> GetDirectorio(int id)
        {
            await Task.Delay(5000);
            var directorio = await _context.Directorio.FindAsync(id);

            if (directorio == null)
            {
                return NotFound();
            }


            return directorio;
        }

        // PUT: api/Directorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirectorio(int id, Directorio directorio)
        {
            if (id != directorio.Id)
            {
                return BadRequest();
            }

            _context.Entry(directorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorioExists(id))
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

        // POST: api/Directorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Directorio>> PostDirectorio(Directorio directorio)
        {
            _context.Directorio.Add(directorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirectorio", new { id = directorio.Id }, directorio);
        }

        // DELETE: api/Directorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirectorio(int id)
        {
            var directorio = await _context.Directorio.FindAsync(id);
            if (directorio == null)
            {
                return NotFound();
            }

            _context.Directorio.Remove(directorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorioExists(int id)
        {
            return _context.Directorio.Any(e => e.Id == id);
        }
    }
}

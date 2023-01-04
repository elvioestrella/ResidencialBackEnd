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
    public class TipoInmueblesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TipoInmueblesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoInmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoInmueble>>> GetTipoInmueble()
        {
            return await _context.TipoInmueble.ToListAsync();
        }

        // GET: api/TipoInmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInmueble>> GetTipoInmueble(int id)
        {
            var tipoInmueble = await _context.TipoInmueble.FindAsync(id);

            if (tipoInmueble == null)
            {
                return NotFound();
            }

            return tipoInmueble;
        }

        // PUT: api/TipoInmuebles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoInmueble(int id, TipoInmueble tipoInmueble)
        {
            if (id != tipoInmueble.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoInmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoInmuebleExists(id))
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

        // POST: api/TipoInmuebles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoInmueble>> PostTipoInmueble(TipoInmueble tipoInmueble)
        {
            _context.TipoInmueble.Add(tipoInmueble);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoInmueble", new { id = tipoInmueble.Id }, tipoInmueble);
        }

        // DELETE: api/TipoInmuebles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoInmueble(int id)
        {
            var tipoInmueble = await _context.TipoInmueble.FindAsync(id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }

            _context.TipoInmueble.Remove(tipoInmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoInmuebleExists(int id)
        {
            return _context.TipoInmueble.Any(e => e.Id == id);
        }
    }
}

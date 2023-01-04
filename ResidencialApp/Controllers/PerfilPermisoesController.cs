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
    public class PerfilPermisoesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public PerfilPermisoesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PerfilPermisoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilPermiso>>> GetPerfilPermiso()
        {
            return await _context.PerfilPermiso.ToListAsync();
        }

        // GET: api/PerfilPermisoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilPermiso>> GetPerfilPermiso(int id)
        {
            var perfilPermiso = await _context.PerfilPermiso.FindAsync(id);

            if (perfilPermiso == null)
            {
                return NotFound();
            }

            return perfilPermiso;
        }

        // PUT: api/PerfilPermisoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfilPermiso(int id, PerfilPermiso perfilPermiso)
        {
            if (id != perfilPermiso.Id)
            {
                return BadRequest();
            }

            _context.Entry(perfilPermiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilPermisoExists(id))
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

        // POST: api/PerfilPermisoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PerfilPermiso>> PostPerfilPermiso(PerfilPermiso perfilPermiso)
        {
            _context.PerfilPermiso.Add(perfilPermiso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfilPermiso", new { id = perfilPermiso.Id }, perfilPermiso);
        }

        // DELETE: api/PerfilPermisoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfilPermiso(int id)
        {
            var perfilPermiso = await _context.PerfilPermiso.FindAsync(id);
            if (perfilPermiso == null)
            {
                return NotFound();
            }

            _context.PerfilPermiso.Remove(perfilPermiso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerfilPermisoExists(int id)
        {
            return _context.PerfilPermiso.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public ExamenController(DbContextSystem context)
        {
            _context = context;
        }

        // GET: api/Examen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.clsExamen>>> Getexamens()
        {
            return await _context.Examens.ToListAsync();
        }

        // GET: api/Examen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.clsExamen>> GetExamen(int id)
        {
            var examen = await _context.Examens.FindAsync(id);

            if (examen == null)
            {
                return NotFound();
            }

            return examen;
        }

        // PUT: api/Examen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamen(int id, Models.clsExamen examen)
        {
            if (id != examen.id)
            {
                return BadRequest();
            }

            _context.Entry(examen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenExists(id))
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

        // POST: api/Examen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.clsExamen>> PostExamen(Models.clsExamen examen)
        {
            _context.Examens.Add(examen);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamen", new { id = examen.id }, examen);
        }

        // DELETE: api/Examen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.clsExamen>> DeleteExamen(int id)
        {
            var examen = await _context.Examens.FindAsync(id);
            if (examen == null)
            {
                return NotFound();
            }

            _context.Examens.Remove(examen);
            await _context.SaveChangesAsync();

            return examen;
        }

        private bool ExamenExists(int id)
        {
            return _context.Examens.Any(e => e.id == id);
        }
    }
}


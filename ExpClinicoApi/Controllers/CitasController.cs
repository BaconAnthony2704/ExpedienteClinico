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
    public class CitasController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public CitasController(DbContextSystem context)
        {
            _context = context;
        }

        // GET: api/ClsCitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ClsCita>>> Getcitas()
        {
            return await _context.citas.ToListAsync();
        }

        //filtrado de historial medico para los paciente
        //silmulado en primer momento por un nombre pasado como string
        // GET: api/ClsCitas/nombre
        [HttpGet("{nombre}")]
        public async Task<ActionResult<IEnumerable<Models.ClsCita>>> GetClsCita(String id)
        {
            var clsCita = await _context.citas.FindAsync(id);

            if (clsCita == null)
            {
                return NotFound();
            }

            return await _context.citas.Where(x => x.nombrePaciente == id).ToListAsync();
        }
        // GET: api/ClsCitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ClsCita>> GetClsCita(int id)
        {
            var clsCita = await _context.citas.FindAsync(id);

            if (clsCita == null)
            {
                return NotFound();
            }

            return clsCita;
        }

        // PUT: api/ClsCitas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClsCita(int id, Models.ClsCita clsCita)
        {
            if (id != clsCita.id)
            {
                return BadRequest();
            }

            _context.Entry(clsCita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClsCitaExists(id))
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

        // POST: api/ClsCitas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.ClsCita>> PostClsCita(Models.ClsCita clsCita)
        {
            _context.citas.Add(clsCita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClsCita", new { id = clsCita.id }, clsCita);
        }

        // DELETE: api/ClsCitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.ClsCita>> DeleteClsCita(int id)
        {
            var clsCita = await _context.citas.FindAsync(id);
            if (clsCita == null)
            {
                return NotFound();
            }

            _context.citas.Remove(clsCita);
            await _context.SaveChangesAsync();

            return clsCita;
        }

        private bool ClsCitaExists(int id)
        {
            return _context.citas.Any(e => e.id == id);
        }
    }
}

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
    public class SolicitudExamenController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public SolicitudExamenController(DbContextSystem context)
        {
            _context = context;
        }

        // GET: api/solicitudExamen
        [HttpGet]
        public async Task<ActionResult<List<Models.clsSolicitudExamen>>> Getsolicitudes()
        {

            
            return await _context.solicitudExamens.ToListAsync();
        }

        // GET: api/solicitudExamen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.clsSolicitudExamen>> GetsolicitudExamen(int id)
        {
            var solicitudExamen = await _context.solicitudExamens.FindAsync(id);
            

            
            //var respuesta= await _context.solicitudExamens.Include(x => x.detalleExamenes).ToListAsync();

            if (solicitudExamen == null)
            {
                return NotFound();
            }

            return await _context.solicitudExamens.Include(x => x.detalleExamenes).FirstOrDefaultAsync(m=> m.id==id); 
        }

        // PUT: api/solicitudExamen/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutsolicitudExamen(int id, Models.clsSolicitudExamen solicitudExamen)
        {
            if (id != solicitudExamen.id)
            {
                return BadRequest();
            }

            _context.Entry(solicitudExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!solicitudExamenExists(id))
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

        // POST: api/solicitudExamen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Models.clsSolicitudExamen>> PostsolicitudExamen(Models.clsSolicitudExamen solicitudExamen)
        {
            
            _context.solicitudExamens.Add(solicitudExamen);
            await _context.SaveChangesAsync();
            foreach ( Models.clsDetalleSolicitudExamen sol in solicitudExamen.detalleExamenes)
            {
                var det = new Models.clsDetalleSolicitudExamen();
                det.clsExamenId = sol.clsExamenId;
                det.clsSolicitudExamenId = sol.clsSolicitudExamenId;
                _context.DetalleSolicitudExamens.Add(det);
                await _context.SaveChangesAsync();
            };
            
            

            return CreatedAtAction("GetsolicitudExamen", new { id = solicitudExamen.id }, solicitudExamen);
        }

        // DELETE: api/solicitudExamen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.clsSolicitudExamen>> DeletesolicitudExamen(int id)
        {
            var solicitudExamen = await _context.solicitudExamens.FindAsync(id);
            if (solicitudExamen == null)
            {
                return NotFound();
            }

            _context.solicitudExamens.Remove(solicitudExamen);
            await _context.SaveChangesAsync();

            return solicitudExamen;
        }

        private bool solicitudExamenExists(int id)
        {
            return _context.solicitudExamens.Any(e => e.id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoConsultaController : Controller
    {

        private readonly DbContextSystem _context;
        public TipoConsultaController(DbContextSystem context)
        {
            _context = context;
        }

        //Get api/TipoConsulta/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsTipoConsulta>>> Listar()
        {
            return await _context.TipoConsulta.ToListAsync();
        }

        //Get api/TipoConsulta/ListId
        [HttpGet("{id}")]
        public async Task<ActionResult<clsTipoConsulta>> ListId(int id)
        {
            var tipoConsulta = await _context.TipoConsulta.FindAsync(id);

            if (tipoConsulta==null)
            {
                return NotFound();
            }
            return tipoConsulta;
        }

        //Put api/TipoConsulta/actualizarTipoConsulta
        [HttpPut("[action]")]
        public async Task<ActionResult<clsTipoConsulta>> actualizarTipoConsulta([FromBody] clsTipoConsulta tipoConsulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (tipoConsulta.idTipoConsulta<=0)
            {
                return BadRequest();
            }

            var tipoConsul = await _context.TipoConsulta.FirstOrDefaultAsync(e => e.idTipoConsulta == tipoConsulta.idTipoConsulta);
            if (tipoConsul==null)
            {
                return NotFound();
            }

            tipoConsul.nombreTipoConsulta = tipoConsulta.nombreTipoConsulta;

            _context.SaveChanges();

            return Ok(new
            {
                ok = true,
                message = "Se ha actualizado el Tipo Consulta de forma correcta"
            });
        }

        //Put api/TipoConsulta/crearTipoConsulta
        [HttpPost("[action]")]
        public async Task<ActionResult<clsTipoConsulta>> crearTipoConsulta([FromBody] clsTipoConsulta tipoConsulta)
        {
            clsTipoConsulta tipoConsul=new clsTipoConsulta();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (tipoConsulta.idTipoConsulta <= 0)
            {
                return BadRequest();
            }

            tipoConsul.idTipoConsulta = tipoConsulta.idTipoConsulta;
            tipoConsul.nombreTipoConsulta = tipoConsulta.nombreTipoConsulta;

            _context.TipoConsulta.Add(tipoConsul);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                ok = true,
                message = "Se ha creado el Tipo Consulta de forma correcta"
            });
        }

        //Get api/TipoConsulta/delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<clsTipoConsulta>> deleteTipoConsulta(int id)
        {
            var tipoConsulta = await _context.TipoConsulta.FindAsync(id);

            if (tipoConsulta == null)
            {
                return NotFound();
            }

            _context.TipoConsulta.Remove(tipoConsulta);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                ok = true,
                message = "Se ha eliminado correctamente"
            });
        }


    }
}

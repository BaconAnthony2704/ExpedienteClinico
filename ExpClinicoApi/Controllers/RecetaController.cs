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

    public class RecetaController : Controller
    {
        private readonly DbContextSystem _context;
        public RecetaController(DbContextSystem context)
        {
            _context = context;
        }

        //Get api/Receta/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsReceta>>> Listar()
        {
            return await _context.Receta.ToListAsync();
        }

        //Get api/Receta/ListId
        [HttpGet("{id}")]
        public async Task<ActionResult<clsReceta>> ListId(int id)
        {
            var receta = await _context.Receta.FindAsync(id);

                if (receta == null)
                {
                    return NotFound();
                }
                return receta;
            }

            //Put api/Receta/actualizarReceta
            [HttpPut("[action]")]
            public async Task<ActionResult<clsReceta>> actualizarReceta([FromBody] clsReceta receta)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (receta.idReceta <= 0)
                {
                    return BadRequest();
                }

                var recet = await _context.Receta.FirstOrDefaultAsync(e => e.idReceta == receta.idReceta);
                if (recet == null)
                {
                    return NotFound();
                }

                recet.descripcionReceta = receta.descripcionReceta;

                _context.SaveChanges();

                return Ok(new
                {
                    ok = true,
                    message = "Se ha actualizado la Receta de forma correcta"
                });
            }

            //Put api/Receta/crearReceta
            [HttpPost("[action]")]
            public async Task<ActionResult<clsReceta>> crearReceta([FromBody] clsReceta receta)
            {
                clsReceta recet = new clsReceta();

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (receta.idReceta <= 0)
                {
                    return BadRequest();
                }

                recet.idReceta = receta.idReceta;
                recet.descripcionReceta = receta.descripcionReceta;

                _context.Receta.Add(recet);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    ok = true,
                    message = "Se ha creado la Receta de forma correcta"
                });
            }

            //Get api/Receta/delete
            [HttpDelete("{id}")]
            public async Task<ActionResult<clsReceta>> deleteReceta(int id)
            {
                var recet = await _context.Receta.FindAsync(id);

                if (recet == null)
                {
                    return NotFound();
                }

                _context.Receta.Remove(recet);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    ok = true,
                    message = "Se ha eliminado correctamente"
                });
            }

 
    }
}

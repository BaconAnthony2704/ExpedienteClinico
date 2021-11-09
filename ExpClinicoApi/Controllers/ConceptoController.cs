using ExpClinicoApi.Models;
using ExpClinicoApi.ViewModels;
using ExpClinicoApi.ViewModels.Crear;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptoController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public ConceptoController(DbContextSystem context)
        {
            _context = context;
        }
        // GET: api/<ConceptoController/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsConcepto>>> Listar()
        {
            var response = await _context.Conceptos.ToListAsync();
            
            return Ok(
                response
                );
        }

        // GET: api/Concepto/ListarCatalogo
        [HttpGet("[action]/{tipo}")]
        public async Task<ActionResult<IEnumerable<clsConcepto>>> ListarCatalogo(string tipo)
        {
            var response = await _context.Conceptos.Where(c=>c.Tipo.Contains(tipo) && c.IsActive==true).ToListAsync();
            var concepts = response.Select(c => new vmConcepto
            {
                codigo=c.Codigo,
                descripcion=c.Descripcion,
                idConcepto=c.IdConcepto,
                nivel=c.Nivel,
                relacion=c.Relacion,
                tipo=c.Tipo
            }).Where(c=>c.nivel>1);
            return Ok(
                concepts
                );
        }

        // GET api/<ConceptoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConceptoController>
        [HttpPost("[action]")]
        public async Task<ActionResult<clsConcepto>> Crear([FromBody] CrearConcepto concepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new {
                        ok=false,
                        msg="El modelo no es valido"
                    });
            }
            clsConcepto cpt = new clsConcepto
            {
                Codigo=concepto.Codigo,
                Descripcion=concepto.Descripcion,
                IsActive=true,
                Modified=DateTime.Now,
                Nivel=concepto.Nivel,
                Relacion=concepto.Relacion,
                Tipo=concepto.Tipo
                
            };
            try
            {
                _context.Conceptos.Add(cpt);
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        ok=true,
                        msg="Se ha ingresado correctamente"
                    }
                );
            }
            catch (Exception)
            {

                return BadRequest(new {ok=false,msg="Problemas en la insersion" });
            }
        }
        // POST api/Concepto/CrearToJson
        [HttpPost("[action]")]
        public async Task<ActionResult<clsConcepto>> Creartojson([FromBody] List<CrearConcepto> listConcepto)
        {
            //List<CrearConcepto> nuevaListaFiltrada = new List<CrearConcepto>();
            //var listaCpt =await  _context.Conceptos.ToListAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new
                    {
                        ok = false,
                        msg = "El modelo no es valido"
                    });
            }
            
            //Llenar la tabla concepto
            foreach (CrearConcepto cpt in listConcepto)
            {
                var c = new clsConcepto {
                    Codigo=cpt.Codigo,
                    Descripcion=cpt.Descripcion,
                    Nivel=cpt.Nivel,
                    Relacion=cpt.Relacion,
                    Tipo=cpt.Tipo,
                    IsActive=true,
                    Modified=DateTime.Now
                };
                _context.Conceptos.Add(c);
            }
            try
            {
                
                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        ok = true,
                        msg = "Se ha ingresado correctamente"
                    }
                );
            }
            catch (Exception e)
            {

                return BadRequest(new { ok = false, msg = "Problemas en la insersion" });
            }
        }



        // PUT api/<ConceptoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConceptoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

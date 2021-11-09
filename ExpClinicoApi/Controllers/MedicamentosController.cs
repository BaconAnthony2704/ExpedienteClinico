using ExpClinicoApi.ViewModels;
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
    public class MedicamentosController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public MedicamentosController(DbContextSystem context)
        {
            _context = context;
        }

        
        // GET: api/<MedicamentosController>
        [HttpGet]
        public async Task<IEnumerable<ExistenciaViewModel>> Get()
        {

            //return await _context.Medicamento.ToListAsync();
            var res = await _context.Medicamento.ToListAsync();
            return res.Select(e => new ExistenciaViewModel
            {
                DESCRIPCION=e.DESCRIPCION,
                ESTADO=(e.IDMEDICAMENTO==1)?"Entrada":"Salida",
                TIPO=e.TIPO,
                EXISTENCIA=e.EXISTENCIA,
                NOMBRE=e.NOMBRE,
                IDMEDICAMENTO=e.IDMEDICAMENTO
            });

        }

        // GET api/<MedicamentosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult< Models.clsMedicamento>> Get(int id)
        {
            return await _context.Medicamento.FindAsync(id);
        }

        // POST api/<MedicamentosController>
        [HttpPost]
        public async Task<ActionResult<Models.clsMedicamento>> Post([FromBody] Models.clsMedicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Medicamento.Add(medicamento);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                ok = true,
                message = "Se ha creado el Tipo Consulta de forma correcta"
            });
        }

        // PUT api/<MedicamentosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.clsMedicamento medicamento)
        {
            
                if (id != medicamento.IDMEDICAMENTO)
                {
                    return BadRequest();
                }

            _context.Medicamento.Update(medicamento);
            await _context.SaveChangesAsync();



            return Ok(new
            {
                ok = true,
                message = "Se ha actualizado el medicamento de forma correcta"
            });
        }
        

        // DELETE api/<MedicamentosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.clsMedicamento>>  Delete(int id)
        {
            var medicameto = await _context.Medicamento.FindAsync(id);
            if (medicameto == null)
            {
                return NotFound();
            }

            _context.Medicamento.Remove(medicameto);
            await _context.SaveChangesAsync();

            return medicameto;
        }
    }
}

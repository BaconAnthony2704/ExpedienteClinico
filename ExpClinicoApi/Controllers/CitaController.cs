using ExpClinicoApi.Models;
using ExpClinicoApi.ViewModels;
using ExpClinicoApi.ViewModels.Crear;
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
    public class CitaController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public CitaController(DbContextSystem context)
        {
            _context = context;

        }

        //GET: api/Cita/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmCita>> Listar()
        {
            var citas = await _context.citas
                .Include(c=>c.paciente.expediente.informacionPersonal)
                .ToListAsync();
            return citas.Select(c => new vmCita
            {
                idCita=c.idCita,
                nombrePaciente=c.paciente.expediente.informacionPersonal.nombre+", "+c.paciente.expediente.informacionPersonal.apellido,
                fechaIngreso=c.fechaIngreso
            });

        }

        //POST: api/Cita/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<clsCita>> Crear([FromBody] CrearVmCita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            

            try
            {
                clsCita nuevaCita = new clsCita
                {
                    fechaIngreso = cita.fechaIngreso,
                    idPaciente = cita.idPaciente
                };

                var ahora = DateTime.Now.AddHours(-6);
                if (nuevaCita.fechaIngreso.Day >= ahora.Day)
                {
                    _context.citas.Add(nuevaCita);
                    _context.SaveChanges();
                    await _context.SaveChangesAsync();

                }
                else
                {
                    return BadRequest(new
                    {
                        ok = false,
                        message = "verifique la fecha de la cita"
                    });
                }
               
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar cita, verifique"
                });
            }
            return Ok(
                new
                {
                    ok = true,
                    message = "Se ha guardado cita de forma correcta"
                });


        }
        // DELETE: api/ClsCita/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<clsCita>> DeleteClsCita(int id)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<clsCita>> GetClsCita(int id)
        {
            var clsCita = await _context.citas.FindAsync(id);

            if (clsCita == null)
            {
                return NotFound();
            }

            return clsCita;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<vmCita>> ObtenerCita()
        {
            var ahora = DateTime.Now.AddHours(-6);


            var citas= await _context.citas
                .Include(x=>x.paciente.expediente.informacionPersonal)
                .Where(x => x.fechaIngreso >= ahora)
                .OrderBy(p => p.fechaIngreso.Hour).Take(5).ToListAsync();
            return citas.Select(x=>new vmCita {
                nombrePaciente=x.paciente.expediente.informacionPersonal.nombre+","+x.paciente.expediente.informacionPersonal.apellido,
                fechaIngreso=x.fechaIngreso,
                idCita=x.idCita

            });
        }
    }
}

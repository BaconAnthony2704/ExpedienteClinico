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
            clsCita nuevaCita = new clsCita
            {
                fechaIngreso = cita.fechaIngreso,
                idPaciente = cita.idPaciente
            };

            try
            {
                _context.citas.Add(nuevaCita);
                _context.SaveChanges();
                await _context.SaveChangesAsync();
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
    }
}

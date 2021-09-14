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
    public class SolicitudExamenController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public SolicitudExamenController(DbContextSystem context)
        {
            _context = context;
        }
        // GET: api/solicitudExamen
        [HttpGet]
        public async Task<IEnumerable<vmSolicitudExamen>> Getsolicitudes()
        {

            var respuesta = await _context.SolicitudExamenes
                .Include(e=>e.medico)
                .Include(e=>e.paciente)
                .Include(e=>e.paciente.expediente)
                .Include(e=>e.paciente.expediente.informacionPersonal)
                .OrderByDescending(e=>e.fechaIngreso)
                .ToListAsync();
            return respuesta.Select(e => new vmSolicitudExamen
            {
                idSolicitudExamen=e.idSolicitudExamen,
                fechaIngreso=e.fechaIngreso,
                paciente=e.paciente.expediente.informacionPersonal.nombre+" "+e.paciente.expediente.informacionPersonal.apellido,
                medico=e.medico.nombre,
                DetalleSolicitudExamenes=listarDetalleExamenes(e.idSolicitudExamen)
            });
        }

        private List<vmDetalleSolicitudExamen> listarDetalleExamenes(int idSolicitudExamen)
        {
            var detalleExamen = _context.DetalleSolicitudExamenes
                .Include(d=>d.SolicitudExamen)
                .Include(d=>d.examen)
                .Where(d => d.idSolicitudExamen == idSolicitudExamen)
                .ToList();
            return detalleExamen.Select(d=>new vmDetalleSolicitudExamen{
                 idDetalleSolicitudExamen=d.idDetalleSolicitudExamen,
                 examen=d.examen.nombre,
                 idExamen=d.idExamen
            }).ToList();
        }
        // POST: api/solicitudExamen
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<clsSolicitudExamen>> Crear([FromBody] CrearVmSolicitudExamen solicitudExamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {
                    ok=false,
                    message="El modelo no es valido"
                });
            }

            //Creamos el modelo solicitudExamen
            clsSolicitudExamen solExamen = new clsSolicitudExamen
            {
                fechaIngreso=DateTime.Now.AddHours(-6),
                idMedicoGrl=solicitudExamen.idMedicoGrl,
                idPaciente=solicitudExamen.idPaciente
            };
            _context.SolicitudExamenes.Add(solExamen);
            _context.SaveChanges();//aqui tengo el idSolicitudExamen



            //llenamos el detalle de la solicitud del examen
            foreach (CrearVmDetalleSolicitudExamen examen in solicitudExamen.solicitudExamenes)
            {
                var exa = new clsDetalleSolicitudExamen
                {
                    idExamen=examen.idExamen,
                    idSolicitudExamen=solExamen.idSolicitudExamen
                };
                _context.Add(exa);
                _context.SaveChanges();

            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest(new {
                    ok=false,
                    message="Problema al guardar examen, verifique"
                });
            }
            return Ok(new {
                ok=true,
                message="Se ha guardado examen de forma correcta"
            });
            
        }


        //api/SolicitudExamen/CrearExamen
        [HttpPost("[action]")]
        public async Task<ActionResult<clsExamen>> CrearExamen([FromBody] clsExamen examen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ok = false,
                    message = "El modelo no es valido"
                });
            }

            //Creamos el modelo Examen
            clsExamen exam = new clsExamen
            {
                nombre = examen.nombre,
                tipoExamen = examen.tipoExamen
            };

            _context.Examenes.Add(exam);
            _context.SaveChanges();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    ok = false,
                    message = "Problema al guardar examen, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado examen de forma correcta"
            });

        }
    }
}

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
    public class DetalleMovimientoController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public DetalleMovimientoController(DbContextSystem context)
        {
            _context = context;
        }
        // GET: api/<DetalleMovimientoController>
        [HttpGet("[action]")]
        public async Task<ActionResult<vmDetalleMovimiento>> Listar() 
        {
            try
            {
                var detalleMov = await _context.DetalleMovimientos
                .Include(m => m.Movimiento)
                .Include(m=>m.Movimiento.Concepto)
                .Include(p => p.Paciente.expediente.informacionPersonal)
                .Where(p=>p.IsActive==true)
                .ToListAsync();
                var dMov = detalleMov.Select(m =>
                new vmDetalleMovimiento
                {
                    documento = m.Movimiento.Documento,
                    fechaIngreso = m.Movimiento.FechaIngreso,
                    idDetalleMovimiento = m.IdDetalleMovimiento,
                    isr = m.Movimiento.Isr,
                    monto =(m.Movimiento.Concepto.Tipo.Equals("I"))?(float) Math.Round(m.Movimiento.Monto,2):(float)Math.Round(  m.Movimiento.Monto*-1,2),
                    codigo=m.Movimiento.Concepto.Codigo,
                    descripcion=m.Movimiento.Documento,
                    nivel=m.Movimiento.Concepto.Nivel,
                    relacion=m.Movimiento.Concepto.Relacion,
                    descripcionConcepto=m.Movimiento.Concepto.Descripcion,
                    tipo=m.Movimiento.Concepto.Tipo,
                    tipoNombre=obtenerTipo(m.Movimiento.Concepto.Codigo[0].ToString(),m.Movimiento.Concepto.Tipo),
                    observacion =(m.Movimiento.Equals(string.Empty))? m.Movimiento.Observacion:"",
                    paciente =(m.IdPaciente!=-1)? m.Paciente.expediente.informacionPersonal.nombre + ", " + m.Paciente.expediente.informacionPersonal.apellido:""

                });
                return Ok(dMov);
            }
            catch (Exception e)
            {

                return BadRequest(
                    new {
                        ok=false,
                        msg="Problema en: "+e.Message
                    });
            }
        }

        private string obtenerTipo(string v,string tipo)
        {
            var resp = _context.Conceptos.ToList()
                .Where(c => c.Codigo[0].ToString()==(v) && c.Tipo==tipo && c.Nivel==1).FirstOrDefault();
            return resp.Descripcion;
        }

        // PUT api/DetalleMovimiento/Eliminar/5
        [HttpPut("[action]/{idDetalleMovimiento}")]
        public async Task<ActionResult> Eliminar(int idDetalleMovimiento)
        {
            var resp = await _context.DetalleMovimientos.FirstOrDefaultAsync(c=>c.IdDetalleMovimiento==idDetalleMovimiento);
            resp.IsActive = false;
            try
            {
               await _context.SaveChangesAsync();
                return Ok(new { ok=true,msg="Se ha eliminado con exito"});
            }
            catch (Exception e)
            {

                return BadRequest(
                    new {
                        ok=false,
                        msg="Hubo un problema en: "+e.Message
                    });
            }
        }

        // POST api/DetalleMovimiento/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult> Crear([FromBody] CrearDetalleMovimiento detalleMovimiento)
        {
            if (detalleMovimiento.idPaciente == 0)
            {
                detalleMovimiento.idPaciente = -1;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new {
                        ok=false,
                        msg="El modelo no es valido"
                    });
            }
            clsMovimiento movimiento = new clsMovimiento
            {
                IdConcepto=detalleMovimiento.idConcepto,
                Documento=detalleMovimiento.documento,
                FechaIngreso=detalleMovimiento.fecha,
                Monto=detalleMovimiento.montoIngreso,
                Isr="S",
                Observacion="",
                IsActive=true,
                Modified=DateTime.Now
            };
            _context.Movimientos.Add(movimiento);
            _context.SaveChanges();

            clsDetalleMovimiento clsDetalle = new clsDetalleMovimiento {
                IdMovimiento=movimiento.IdMovimiento,
                IdPaciente=detalleMovimiento.idPaciente,
                IsActive=true,
                Modified=DateTime.Now
            };
            _context.DetalleMovimientos.Add(clsDetalle);
            _context.SaveChanges();
            try
            {
                await _context.SaveChangesAsync();
                return Ok(
                    new {
                        ok=true,
                        msg="Detalle de movimiento ingresado correctamente"
                    });
            }
            catch (Exception e)
            {
                return BadRequest(
                    new {
                        ok=false,
                        msg="Problemas en: "+e.Message
                    });
                throw;
            }
        }

        // PUT api/<DetalleMovimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DetalleMovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

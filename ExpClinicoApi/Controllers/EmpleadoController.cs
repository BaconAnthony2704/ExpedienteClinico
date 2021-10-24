using ExpClinicoApi.Models;
using ExpClinicoApi.ViewModels;
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
    public class EmpleadoController : Controller
    {
        private readonly DbContextSystem _context;

        public EmpleadoController(DbContextSystem context)
        {
            _context = context;
        }


        //Get api/Empleado/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsEmpleado>>> Listar()
        {
            return await _context.Empleado.ToListAsync();
        }


        //Post api/Empleado/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> Crear([FromBody] clsEmpleado empleado){
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            clsEmpleado emp = new clsEmpleado
            {
                nombreEmpleado = empleado.nombreEmpleado,
                dui = empleado.dui,
                nit = empleado.nit,
                fechaIngreso = DateTime.Now,
                titulo = empleado.titulo,
                cargo = empleado.cargo,
                sueldo = empleado.sueldo

            };

            _context.Empleado.Add(emp);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }

        //Post api/Empleado/CrearDescuento
        [HttpPost("[action]")]
        public async Task<ActionResult<clsDescuento>> CrearDescuento([FromBody] clsDescuento descuento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            clsDescuento des = new clsDescuento
            {
                descripcion= descuento.descripcion ,
                monto=descuento.monto,
                fecha = DateTime.Now,
                idEmpleado=descuento.idEmpleado

            };

            _context.Descuento.Add(des);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar Descuento al Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }



        //Get api/Empleado/ListarSancion
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsSancion>>> ListarSancion()
        {
            return await _context.Sancion
                .Include(s=>s.empleado)
                .ToListAsync();
        }

        //Get api/Empleado/ListarDescuento
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsDescuento>>> ListarDescuento()
        {
            return await _context.Descuento
                .Include(s => s.empleado)
                .ToListAsync();
        }

        //Get api/Empleado/ListarAnticipo
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsAnticipo>>> ListarAnticipo()
        {
            return await _context.Anticipo
                .Include(s => s.empleado)
                .ToListAsync();
        }

        //Get api/Empleado/ListarPermiso
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsPermiso>>> ListarPermiso()
        {
            return await _context.Permiso
                .Include(s => s.empleado)
                .ToListAsync();
        }

        //Get api/Empleado/ListarAsistenciaLaboral
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsAsistenciaLaboral>>> ListarAsistenciaLaboral()
        {
            return await _context.AsistenciaLaboral
                .Include(s => s.permiso).ThenInclude(p=>p.empleado)
                .ToListAsync();
        }


        // DELETE: api/Empleado/idDescuento
        [HttpDelete("{idDescuento}")]
        public async Task<ActionResult<clsDescuento>> DeleteDescuento(int idDescuento)
        {
            var descuento = await _context.Descuento.FindAsync(idDescuento);
            if (descuento == null)
            {
                return NotFound();
            }

            _context.Descuento.Remove(descuento);
            await _context.SaveChangesAsync();

            return descuento;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

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

        /*Web Service
         * para
         * empleado
         */
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

        //Post api/Empleado/editar
        [HttpPut("[action]")]
        public async Task<ActionResult<clsEmpleado>> Editar([FromBody] clsEmpleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Empleado no Encontrado"
                });
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al Editar Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        // DELETE: api/Empleado/delteEmpleado
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> deleteEmpleado(clsEmpleado empleado)
        {
            var emp = await _context.Empleado.FindAsync(empleado.idEmpleado);
            if (emp == null)
            {
                return Ok(
                        new
                        {
                            ok = false,
                            message = "Empleado No Encontrado"
                        });
            }

            _context.Empleado.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "Empledo Eliminado Correctamente"
                });
        }





        /*Web Service
         * para
         * Descuento
         */
        //Post api/Empleado/CrearDescuento
        [HttpPost("[action]")]
        public async Task<ActionResult<clsDescuento>> CrearDescuento([FromBody] clsDescuento descuento)
        {
            if (!ModelState.IsValid)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Descuento no Encontrado"
                });
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
        //Post api/Empleado/editarDescuento
        [HttpPut("[action]")]
        public async Task<ActionResult<clsDescuento>> editarDescuento([FromBody] clsDescuento descuento)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Descuento no Encontrado"
                });
            }

            _context.Entry(descuento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Descuento no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        //Get api/Empleado/ListarDescuento
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsDescuento>>> ListarDescuento()
        {
            return await _context.Descuento
                .Include(s => s.empleado)
                .ToListAsync();
        }
        //Get api/Empleado/ListarDescuentoUno
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> ListarDescuentoUno(clsDescuento descuento)
        {
            clsDescuento des = await _context.Descuento.FindAsync(descuento.idDescuento);
            clsEmpleado emp = await _context.Empleado.FindAsync(des.idEmpleado);

            return emp;
        }
        // DELETE: api/Empleado/deleteDescuento
        [HttpPost("[action]")]
        public async Task<ActionResult<clsDescuento>> deleteDescuento(clsDescuento descuento)
        {
            var des = await _context.Descuento.FindAsync(descuento.idDescuento);
            if (des == null)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Descuento No encontrado"
                });
            }

            _context.Descuento.Remove(des);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "Descuento Eliminado Correctamente"
                });
        }





        /*Web Service
         * para
         * Anticipo
         */
        //Get api/Empleado/ListarAnticipo
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsAnticipo>>> ListarAnticipo()
        {
            return await _context.Anticipo
                .Include(s => s.empleado)
                .ToListAsync();
        }
        //Post api/Empleado/CrearAnticipo
        [HttpPost("[action]")]
        public async Task<ActionResult<clsAnticipo>> CrearAnticipo([FromBody] clsAnticipo anticipo)
        {
            if (!ModelState.IsValid)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Anticipo no Encontrado"
                });
            }

            clsAnticipo ant = new clsAnticipo
            {
                descripcion = anticipo.descripcion,
                monto = anticipo.monto,
                fecha = anticipo.fecha,
                idEmpleado = anticipo.idEmpleado

            };

            _context.Anticipo.Add(ant);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar Anticipo al Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }
        //Post api/Empleado/editarAnticipo
        [HttpPut("[action]")]
        public async Task<ActionResult<clsAnticipo>> editarAnticipo([FromBody] clsAnticipo anticipo)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Anticipo no Encontrado"
                });
            }

            _context.Entry(anticipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Anticipo no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        // DELETE: api/Empleado/deleteAnticipo
        [HttpPost("[action]")]
        public async Task<ActionResult<clsAnticipo>> deleteAnticipo(clsAnticipo anticipo)
        {
            var ant = await _context.Anticipo.FindAsync(anticipo.idAnticipo);
            if (ant == null)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Anticipo No encontrado"
                });
            }

            _context.Anticipo.Remove(ant);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "Anticipo Eliminado Correctamente"
                });
        }
        //Get api/Empleado/ListarAnticipoUno
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> ListarAnticipoUno(clsAnticipo anticipo)
        {
            clsAnticipo ant = await _context.Anticipo.FindAsync(anticipo.idAnticipo);
            clsEmpleado emp = await _context.Empleado.FindAsync(ant.idEmpleado);

            return emp;
        }





        /*Web Service
         * para
         * Permiso
         */
        //Get api/Empleado/ListarPermiso
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsPermiso>>> ListarPermiso()
        {
            return await _context.Permiso
                .Include(s=>s.empleado)
                .ToListAsync();
        }
        //Post api/Empleado/CrearPermiso
        [HttpPost("[action]")]
        public async Task<ActionResult<clsPermiso>> CrearPermiso([FromBody] clsPermiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Permiso no Encontrado"
                });
            }

            clsPermiso per = new clsPermiso
            {
                descripcion = permiso.descripcion,
                fecha = permiso.fecha,
                idEmpleado = permiso.idEmpleado

            };

            _context.Permiso.Add(per);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar Permiso al Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }
        //Post api/Empleado/editarPermiso
        [HttpPut("[action]")]
        public async Task<ActionResult<clsPermiso>> editarPermiso([FromBody] clsPermiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Permiso no Encontrado"
                });
            }

            _context.Entry(permiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Permiso no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        // DELETE: api/Empleado/deletePermiso
        [HttpPost("[action]")]
        public async Task<ActionResult<clsPermiso>> deletePermiso(clsPermiso permiso)
        {
            var per = await _context.Permiso.FindAsync(permiso.idPermiso);
            if (per == null)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Permiso No encontrado"
                });
            }

            _context.Permiso.Remove(per);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "Permiso Eliminado Correctamente"
                });
        }
        //Get api/Empleado/ListarPermisoUno
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> ListarPermisoUno(clsPermiso permiso)
        {
            clsPermiso per = await _context.Permiso.FindAsync(permiso.idPermiso);
            clsEmpleado emp = await _context.Empleado.FindAsync(per.idEmpleado);

            return emp;
        }





        /*Web Service
         * para
         * Sancion
         */
        //Get api/Empleado/ListarSancion
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsSancion>>> ListarSancion()
        {
            return await _context.Sancion
                .Include(s => s.empleado)
                .ToListAsync();
        }
        //Post api/Empleado/CrearSancion
        [HttpPost("[action]")]
        public async Task<ActionResult<clsSancion>> CrearSancion([FromBody] clsSancion sancion)
        {
            if (!ModelState.IsValid)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Sancion no Encontrado"
                });
            }

            clsSancion san = new clsSancion
            {
                descripcion = sancion.descripcion,
                fecha = sancion.fecha,
                idEmpleado = sancion.idEmpleado

            };

            _context.Sancion.Add(san);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al guardar Sancion al Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }
        //Post api/Empleado/editarSancion
        [HttpPut("[action]")]
        public async Task<ActionResult<clsSancion>> editarSancion([FromBody] clsSancion sancion)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Sancion no Encontrado"
                });
            }

            _context.Entry(sancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Sancion no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        // DELETE: api/Empleado/deleteSancion
        [HttpPost("[action]")]
        public async Task<ActionResult<clsSancion>> deleteSancion(clsSancion sancion)
        {
            var san = await _context.Sancion.FindAsync(sancion.idSancion);
            if (san == null)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Sancion No encontrado"
                });
            }

            _context.Sancion.Remove(san);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "Sancion Eliminado Correctamente"
                });
        }
        //Get api/Empleado/ListarSancionUno
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> ListarSancionUno(clsSancion sancion)
        {
            clsSancion san = await _context.Sancion.FindAsync(sancion.idSancion);
            clsEmpleado emp = await _context.Empleado.FindAsync(san.idEmpleado);

            return emp;
        }





        /*Web Service
         * para
         * AsistenciaLaboral
         */
        //Get api/Empleado/ListarAsistenciaLaboral
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsAsistenciaLaboral>>> ListarAsistenciaLaboral()
        {
            var asistencia= await _context.AsistenciaLaboral
                .Include(p => p.permiso)
                .Include(e => e.empleado)
                .ToListAsync();

            foreach (var a in asistencia)
            {
                if (a.sePresento==true)
                {
                    if (a.permiso == null)
                    {
                        clsPermiso per = new clsPermiso
                        {
                            idPermiso = 0,
                            descripcion = "Se Presento",
                            fecha = DateTime.Now,
                            idEmpleado = 0
                        };
                        a.permiso = per;
                    }
                }
                else
                {
                    if (a.permiso == null)
                    {
                        clsPermiso per = new clsPermiso
                        {
                            idPermiso = 0,
                            descripcion = "Sin Permiso",
                            fecha = DateTime.Now,
                            idEmpleado = 0
                        };
                        a.permiso = per;
                    }
                }
                
            }

            return asistencia;
        }
        //Post api/Empleado/CrearAsistenciaLaboral
        [HttpPost("[action]")]
        public async Task<ActionResult<clsAsistenciaLaboral>> CrearAsistenciaLaboral([FromBody] clsAsistenciaLaboral asistenciaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "Asistencia Laboral No Valida"
                });
            }

            clsAsistenciaLaboral asi = new clsAsistenciaLaboral
            {
                sePresento = asistenciaLaboral.sePresento,
                conPermiso = asistenciaLaboral.conPermiso,
                fecha = asistenciaLaboral.fecha,
                idPermiso = asistenciaLaboral.idPermiso,
                idEmpleado = asistenciaLaboral.idEmpleado

            };

            _context.AsistenciaLaboral.Add(asi);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "No se Guardo Asistencia Laboral del Empleado, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }
        //Post api/Empleado/editarAsistenciaLaboral
        [HttpPut("[action]")]
        public async Task<ActionResult<clsAsistenciaLaboral>> editarAsistenciaLaboral([FromBody] clsAsistenciaLaboral asistenciaLaboral)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new
                {
                    ok = false,
                    message = "Asistencia Laboral no Encontrado"
                });
            }

            _context.Entry(asistenciaLaboral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Asistencia Laboral no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se Edito correctamente"
            });

        }
        // DELETE: api/Empleado/deleteAsistenciaLaboral
        [HttpPost("[action]")]
        public async Task<ActionResult<clsAsistenciaLaboral>> deleteAsistenciaLaboral(clsAsistenciaLaboral asistenciaLaboral)
        {
            var asi = await _context.AsistenciaLaboral.FindAsync(asistenciaLaboral.idAsistenciaLaboral);
            if (asi == null)
            {
                return Ok(
                new
                {
                    ok = false,
                    message = "AsistenciaLaboral No encontrado"
                });
            }

            _context.AsistenciaLaboral.Remove(asi);
            await _context.SaveChangesAsync();

            return Ok(
                new
                {
                    ok = true,
                    message = "AsistenciaLaboral Eliminado Correctamente"
                });
        }
        //Get api/Empleado/ListarAsistenciaLaboralUno
        [HttpPost("[action]")]
        public async Task<ActionResult<clsPermiso>> ListarAsistenciaLaboralUno(clsPermiso permiso)
        {
            clsEmpleado asi = await _context.Empleado.FindAsync(permiso.idEmpleado);
            clsPermiso per = await _context.Permiso.FindAsync(asi.idEmpleado);

            return per;
        }
        //Get api/Empleado/ListarAsistenciaLaboralDos
        [HttpPost("[action]")]
        public async Task<ActionResult<clsEmpleado>> ListarAsistenciaLaboralDos(clsAsistenciaLaboral asistenciaLaboral)
        {
            clsAsistenciaLaboral asi = await _context.AsistenciaLaboral.FindAsync(asistenciaLaboral.idAsistenciaLaboral);
            clsEmpleado emp = await _context.Empleado.FindAsync(asi.idEmpleado);

            return emp;
        }






        /*Web Service
         * para
         * planilla
        */
        //Get api/Empleado/Listar
        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<vmPlanilla>>> ListarPlanilla(vmTotales fecha)
        {
            var descuentos = await _context.Descuento
                               .Where(s => s.fecha >= fecha.fechaInicio && s.fecha <= fecha.fechaFinal)                       
                                .ToArrayAsync();
            var empleados = await _context.Empleado.ToArrayAsync();
            var anticipos = await _context.Anticipo
                                .Where(a => a.fecha >= fecha.fechaInicio && a.fecha <= fecha.fechaFinal)
                                .ToListAsync();
            List <vmPlanilla> planilla = new List<vmPlanilla>();

            foreach (var e in empleados)
            {
                float totaldescuento = 0;
                float totalanticipo = 0;
                vmPlanilla plan = new vmPlanilla();
                plan.idEmpleado = e.idEmpleado;
                plan.nombreEmpleado = e.nombreEmpleado;
                plan.cargo = e.cargo;
                plan.sueldo = e.sueldo;
                plan.montoAnticipo = 0;
                plan.montoDescuento = 0;
                plan.isss = Convert.ToSingle(e.sueldo * 0.003);
                plan.afp = Convert.ToSingle(e.sueldo * 0.0725);
                plan.totalDescuento = 0;
                plan.totalPagar = 0;

                foreach (var d in descuentos)
                {
                    if (e.idEmpleado==d.idEmpleado)
                    {
                        totaldescuento = Convert.ToSingle(totaldescuento + d.monto);
                    }
                }
                foreach (var a in anticipos)
                {
                    if (e.idEmpleado == a.idEmpleado)
                    {
                        totalanticipo = Convert.ToSingle(totalanticipo + a.monto);
                    }
                }
                plan.montoDescuento = totaldescuento;
                plan.montoAnticipo = totalanticipo;
                planilla.Add(plan);
            }

            foreach (var p in planilla)
            {
                p.totalDescuento = p.montoAnticipo + p.montoDescuento + p.isss + p.afp;
            }
            foreach (var p in planilla)
            {
                p.totalPagar = p.sueldo - p.totalDescuento;
            }
            float totalSueldo = 0;
            float totalAnticipo = 0;
            float totalDescuento = 0;
            float totalISSS = 0;
            float totalAFP = 0;
            float totalDescuentos = 0;
            float totalPagar = 0;
            foreach (var p in planilla)
            {
                totalSueldo = totalSueldo + p.sueldo;
                totalAnticipo = totalAnticipo + p.montoAnticipo;
                totalDescuento = totalDescuento + p.montoDescuento;
                totalISSS = totalISSS + p.isss;
                totalAFP = totalAFP + p.afp;
                totalDescuentos = totalDescuentos + p.totalDescuento;
                totalPagar = totalPagar + p.totalPagar;
            }
            vmPlanilla plan1 = new vmPlanilla();
            plan1.idEmpleado = 0;
            plan1.nombreEmpleado = "";
            plan1.cargo = "TOTALES";
            plan1.sueldo = totalSueldo;
            plan1.montoAnticipo = totalAnticipo;
            plan1.montoDescuento = totalDescuento;
            plan1.isss = totalISSS;
            plan1.afp = totalAFP;
            plan1.totalDescuento = totalDescuentos;
            plan1.totalPagar = totalPagar;

            planilla.Add(plan1);



            return planilla;
        }

        //Get api/Empleado/CrearPlanilla
        [HttpPost("[action]")]
        public async Task<ActionResult<IEnumerable<vmPlanilla>>> CrearPlanilla(vmTotales fecha)
        {
            var descuentos = await _context.Descuento
                               .Where(s => s.fecha >= fecha.fechaInicio && s.fecha <= fecha.fechaFinal)
                                .ToArrayAsync();
            var empleados = await _context.Empleado.ToArrayAsync();
            var anticipos = await _context.Anticipo
                                .Where(a => a.fecha >= fecha.fechaInicio && a.fecha <= fecha.fechaFinal)
                                .ToListAsync();
            List<vmPlanilla> planilla = new List<vmPlanilla>();

            foreach (var e in empleados)
            {
                float totaldescuento = 0;
                float totalanticipo = 0;
                vmPlanilla plan = new vmPlanilla();
                plan.idEmpleado = e.idEmpleado;
                plan.nombreEmpleado = e.nombreEmpleado;
                plan.cargo = e.cargo;
                plan.sueldo = e.sueldo;
                plan.montoAnticipo = 0;
                plan.montoDescuento = 0;
                plan.isss = Convert.ToSingle(e.sueldo * 0.003);
                plan.afp = Convert.ToSingle(e.sueldo * 0.0725);
                plan.totalDescuento = 0;
                plan.totalPagar = 0;

                foreach (var d in descuentos)
                {
                    if (e.idEmpleado == d.idEmpleado)
                    {
                        totaldescuento = Convert.ToSingle(totaldescuento + d.monto);
                    }
                }
                foreach (var a in anticipos)
                {
                    if (e.idEmpleado == a.idEmpleado)
                    {
                        totalanticipo = Convert.ToSingle(totalanticipo + a.monto);
                    }
                }
                plan.montoDescuento = totaldescuento;
                plan.montoAnticipo = totalanticipo;
                planilla.Add(plan);
            }

            foreach (var p in planilla)
            {
                p.totalDescuento = p.montoAnticipo + p.montoDescuento + p.isss + p.afp;
            }
            foreach (var p in planilla)
            {
                p.totalPagar = p.sueldo - p.totalDescuento;
            }
            float totalSueldo = 0;
            float totalAnticipo = 0;
            float totalDescuento = 0;
            float totalISSS = 0;
            float totalAFP = 0;
            float totalDescuentos = 0;
            float totalPagar = 0;
            foreach (var p in planilla)
            {
                totalSueldo = totalSueldo + p.sueldo;
                totalAnticipo = totalAnticipo + p.montoAnticipo;
                totalDescuento = totalDescuento + p.montoDescuento;
                totalISSS = totalISSS + p.isss;
                totalAFP = totalAFP + p.afp;
                totalDescuentos = totalDescuentos + p.totalDescuento;
                totalPagar = totalPagar + p.totalPagar;
            }
            vmPlanilla plan1 = new vmPlanilla();
            plan1.idEmpleado = 0;
            plan1.nombreEmpleado = "";
            plan1.cargo = "TOTALES";
            plan1.sueldo = totalSueldo;
            plan1.montoAnticipo = totalAnticipo;
            plan1.montoDescuento = totalDescuento;
            plan1.isss = totalISSS;
            plan1.afp = totalAFP;
            plan1.totalDescuento = totalDescuentos;
            plan1.totalPagar = totalPagar;

            planilla.Add(plan1);

            clsPlanilla plan2 = new clsPlanilla
            {
                descripcion = fecha.descripcion,
                fecha=fecha.fechaFinal,
                activo=true,
                totalSalario = totalSueldo,
                totalAnticipo = totalAnticipo,
                totalDescuento = totalDescuento,
                isssTotal = totalISSS,
                totalAfp = totalAFP,
                totalDescuentos = totalDescuentos,
                totalPagar = totalPagar,
            };

            _context.Planilla.Add(plan2);

            clsMovimiento movimiento = new clsMovimiento
            {
                IdConcepto = 5102001,
                Documento = "",
                FechaIngreso = DateTime.Now,
                Monto = totalPagar,
                Isr = "S",
                Observacion = "",
                IsActive = true,
                Modified = DateTime.Now
            };
            _context.Movimientos.Add(movimiento);
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
                    message = "No se Guardo Correctamente, verifique"
                });
            }
            return planilla;
        }
        //Get api/Empleado/cerrarPlanilla
        [HttpPut("[action]")]
        public async Task<ActionResult<IEnumerable<clsPlanilla>>> cerrarPlanilla(vmTotales fecha)
        {
            var planilla = await _context.Planilla
                               .Where(s => s.fecha == fecha.fechaFinal)
                                .ToArrayAsync();


            foreach (var p in planilla)
            {
                p.activo = false;
                _context.Entry(p).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "no Encontrado"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Planilla Cerrada Correctamente correctamente"
            });
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}

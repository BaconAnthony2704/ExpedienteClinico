using Microsoft.AspNetCore.Mvc;
using ExpClinicoApi.Models;
using ExpClinicoApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : Controller
    {
        private readonly DbContextSystem _context;
        
        public ConsultaController(DbContextSystem context)
        {
            _context = context;
        }

        //Get api/Consulta/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmConsulta>> Listar()
        {
            
            var consulta = await _context.Consulta
                .Include(e => e.historialMedico).Include(h=>h.historialMedico.medicoGrl)
                .Include(e => e.historialMedico).Include(h => h.historialMedico.receta)
                .Include(e=>e.historialMedico)
                .Include(e => e.paciente).ThenInclude(p=>p.expediente).ThenInclude(ex=>ex.informacionPersonal).ThenInclude(inf=>inf.genero)
                .Include(e => e.paciente).ThenInclude(p => p.expediente).ThenInclude(ex => ex.informacionAdicional).ThenInclude(ind=>ind.estadoCivil)
                .Include(e=>e.tipoConsulta)
                .ToListAsync();

            return consulta.Select(e => new vmConsulta
            {
                idExpediente = e.paciente.idExpediente,
                nombrePaciente = e.paciente.expediente.informacionPersonal.nombre,
                edad = 2021 - e.paciente.expediente.informacionPersonal.fechaNacimiento.Year,
                sexo = e.paciente.expediente.informacionPersonal.genero.tipo,
                telefono = int.Parse(e.paciente.expediente.informacionAdicional.telefonoDomicilio),
                estadoCivil = e.paciente.expediente.informacionAdicional.estadoCivil.estado,
                doctor = e.historialMedico.medicoGrl.nombre,
                tipoConsulta = e.tipoConsulta.nombreTipoConsulta,
                fecha = DateTime.Now,
                consultaPor = "",
                enfermedadActual = "",
                antecedentesPersonales = "",
                antecedentesFamiliares = "",
                examenesClinicos = "",
                exploracionFisica = "",
                diagnosticoPrincipal = "",
                otroDiagnostico = "",
                tratamiento = "",
                observaciones = "",
                idConsulta = e.idConsulta,
                idReceta = 1,
                descripcionReceta = "",
                idExameneClinico = 0,
                descripcionExamenClinico = "",
                presionArterial = 0,
                talla = 0,
                peso = 0,
                temperatura = 0,
                frecuenciaCardiaca = 0,
                frecuenciaRespiratoria = 0,
                idPaciente = e.paciente.idPaciente,
                idMedicoGrl = e.historialMedico.medicoGrl.idMedicoGrl
            }); ;
        }


        //Get api/Consulta/Listar
        [HttpGet("{id}")]
        public async Task<IEnumerable<vmConsulta>> Listar(int id)
        {

            var consulta = await _context.Consulta
                .Include(e => e.historialMedico).Include(h => h.historialMedico.medicoGrl)
                .Include(e => e.historialMedico).Include(h => h.historialMedico.receta)
                .Include(e => e.historialMedico)
                .Include(e => e.paciente).ThenInclude(p => p.expediente).ThenInclude(ex => ex.informacionPersonal).ThenInclude(inf => inf.genero)
                .Include(e => e.paciente).ThenInclude(p => p.expediente).ThenInclude(ex => ex.informacionAdicional).ThenInclude(ind => ind.estadoCivil)
                .Include(e => e.tipoConsulta).Where(e => e.paciente.idExpediente == id)
                .ToListAsync();

            return consulta.Select(e => new vmConsulta
            {
                idExpediente = e.paciente.idExpediente,
                nombrePaciente = e.paciente.expediente.informacionPersonal.nombre,
                edad = 2021 - e.paciente.expediente.informacionPersonal.fechaNacimiento.Year,
                sexo = e.paciente.expediente.informacionPersonal.genero.tipo,
                telefono = int.Parse(e.paciente.expediente.informacionAdicional.telefonoDomicilio),
                estadoCivil = e.paciente.expediente.informacionAdicional.estadoCivil.estado,
                doctor = "",
                tipoConsulta = "",
                fecha = DateTime.Now,
                consultaPor = "",
                enfermedadActual = "",
                antecedentesPersonales = "",
                antecedentesFamiliares = "",
                examenesClinicos = "",
                exploracionFisica = "",
                diagnosticoPrincipal = "",
                otroDiagnostico = "",
                tratamiento = "",
                observaciones = "",
                idConsulta = 0,
                idReceta = 1,
                descripcionReceta = "",
                idExameneClinico = 0,
                descripcionExamenClinico = "",
                presionArterial = 0,
                talla = 0,
                peso = 0,
                temperatura = 0,
                frecuenciaCardiaca = 0,
                frecuenciaRespiratoria = 0,
                idPaciente = 0,
                idMedicoGrl = 0
            }); ;
        }

        /*Post api/Consulta/crearConsulta
        [HttpPost("[action]")]
        public async Task<ActionResult<clsConsulta>> crearConsulta([FromBody] vmConsulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }




            return 0;
        }*/



    }
}

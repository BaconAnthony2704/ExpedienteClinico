using ExpClinicoApi.Models;
using ExpClinicoApi.Models.Global;
using ExpClinicoApi.ViewModels;
using ExpClinicoApi.ViewModels.Crear;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                idTipoConsulta = 0,
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
                presionArterial = "",
                talla = "",
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
                idTipoConsulta = 0,
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
                presionArterial = "",
                talla = "",
                peso = 0,
                temperatura = 0,
                frecuenciaCardiaca = 0,
                frecuenciaRespiratoria = 0,
                idPaciente = e.paciente.idPaciente,
                idMedicoGrl = 0
            }); ;
        }

        //Post api/Consulta/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<clsConsulta>> Crear([FromBody] vmConsulta consulta)
        {
            if (consulta.nombrePaciente == null)
            {
                consulta.nombrePaciente = "Bryan";
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            clsReceta receta = new clsReceta {
                descripcionReceta = consulta.descripcionReceta
            };

            _context.Receta.Add(receta);
            _context.SaveChanges();

            clsSignosVitales signos = new clsSignosVitales {
                presionArterial = consulta.presionArterial,
                talla = consulta.talla,
                peso = consulta.peso,
                temperatura = consulta.temperatura,
                frecuenciaCardiaca = consulta.frecuenciaCardiaca,
                frecuenciaRespiratoria = consulta.frecuenciaRespiratoria
            };

            _context.SignosVitales.Add(signos);
            _context.SaveChanges();

            CrearVmHistorialMedico historia = new CrearVmHistorialMedico
            {
                idmedicoGrl = consulta.idMedicoGrl,
                idReceta = receta.idReceta,
                idSignosVitales = signos.idSignosVitales,
                idHospital = 1,
                idSeguro = 4,
                dentistaFamilia = "Dra Farela",
                consultaPor = consulta.consultaPor,
                enfermedadActual = consulta.enfermedadActual,
                antecedentesFamiliares = consulta.antecedentesFamiliares,
                antecedentesPersonales = consulta.antecedentesPersonales,
                examenesClinicos = consulta.examenesClinicos,
                exploracionFisica = consulta.exploracionFisica,
                diagnosticoPrincipal = consulta.diagnosticoPrincipal,
                otroDiagnostico = consulta.otroDiagnostico,
                tratamiento = consulta.tratamiento,
                observaciones = consulta.observaciones,
                idSolicitudExamen =0
        };

            _context.CrearHistorialMedico.Add(historia);
            _context.SaveChanges();

            clsConsulta consulta1 = new clsConsulta
            {
                idPaciente = consulta.idPaciente,
                idHistorialMedico = historia.idHistorialMedico,
                idTipoConsulta = consulta.idTipoConsulta,
                fechaConsulta = consulta.fecha
            };

            _context.Consulta.Add(consulta1);
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
                    message = "Problemas al guardar Consulta, verifique"
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha guardado"
            });

        }



    }
}

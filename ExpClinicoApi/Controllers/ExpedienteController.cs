using ExpClinicoApi.Models;
using ExpClinicoApi.Models.Global;
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
    public class ExpedienteController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public ExpedienteController(DbContextSystem context)
        {
            _context = context;
        }
        
        //GET: api/Expediente/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmExpediente>> Listar()
        {
            var expediente = await _context.Expedientes
                .Include(e=>e.informacionPersonal)
                .Include(e=>e.informacionPersonal.genero)
                .Include(e=>e.informacionAdicional)
                .Include(e=>e.informacionAdicional.estadoCivil)
                .Include(e => e.exploracionFisica)
                .Include(e => e.exploracionFisica.tipoPiel)
                .Include(e => e.exploracionFisica.colorCabello)
                .Include(e=>e.historialMedico)
                .Include(e=>e.historialMedico.medicoGrl)
                .Include(e=>e.historialMedico.hospital)
                .Include(e=>e.historialMedico.seguro)
                //.Include(e=>e.alergias)
                //.Include(e=>e.incapacidades)
                .ToListAsync();
            
            return expediente.Select(exp=>new vmExpediente
            {
                titulo=exp.informacionPersonal.titulo,
                nombrePaciente=exp.informacionPersonal.nombre,
                apellidoPaciente=exp.informacionPersonal.apellido,
                domicilioPaciente=exp.informacionPersonal.domicilio,
                fechaNacimiento=exp.informacionPersonal.fechaNacimiento,
                genero=exp.informacionPersonal.genero.tipo,
                NoISSS=exp.informacionPersonal.NoISSS,
                LugarNacimiento=exp.informacionAdicional.lugarNacimiento,
                telefonoDomicilio=exp.informacionAdicional.telefonoDomicilio,
                telefonoOficina=exp.informacionAdicional.telefonoOficina,
                correo=exp.informacionAdicional.correo,
                responsableA=exp.informacionAdicional.responsableA,
                estadoCivil=exp.informacionAdicional.estadoCivil.estado,
                nvoPaciente=exp.informacionAdicional.NvoPaciente,
                fechaIngreso=exp.informacionAdicional.fechaIngreso,
                altura = exp.exploracionFisica.altura,
                peso = exp.exploracionFisica.peso,
                tipoPiel = exp.exploracionFisica.tipoPiel.tipo,
                marcaNaci = exp.exploracionFisica.marcaNaci,
                imc = exp.exploracionFisica.peso / Math.Pow(exp.exploracionFisica.altura, 2),
                colorCabello = exp.exploracionFisica.colorCabello.colorCabello,
                ocupaLentes = exp.exploracionFisica.OcupaLentes,
                presentaDisc = exp.exploracionFisica.PresentaDisca,
                problemaAuditivo = exp.exploracionFisica.ProblemaAuditivo,
                medicoGrl = exp.historialMedico.medicoGrl.nombre,
                telefonoMedico=exp.historialMedico.medicoGrl.telefono,
                dentistaFamilia=exp.historialMedico.dentistaFamilia,
                direccionMedico=exp.historialMedico.medicoGrl.direccionMedico,
                hospital=exp.historialMedico.hospital.nombre,
                seguro=exp.historialMedico.seguro.NoPoliza,
                ultimaVacuna=exp.historialMedico.ultimaVacuna,
                conyugue=exp.informacionAdicional.conyugue,
                ExpedienteNo=generarNumExpediente(),
                poliza=exp.historialMedico.seguro.nombre,
                alergias=obtenerAlergias(exp.idExpediente),
                incapacidades=obtenerIncapacidades(exp.idExpediente),
                fechaCreacion=exp.fechaCreacion,
                idExpediente=exp.idExpediente,
                idInformacionPersonal=exp.informacionPersonal.idInformacionPersonal,
                isActive=exp.isActive

            }).Where(e=>e.isActive==1);
        }

        //POST: api/Expediente/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<clsExpediente>> Crear([FromBody] CrearVmExpediente expediente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            clsInformacionPersonal informacionPersonal = new clsInformacionPersonal
            {
                titulo=createTitle(),
                nombre=expediente.nombrePaciente,
                apellido=expediente.apellidoPaciente,
                domicilio=expediente.domicilioPaciente,
                fechaNacimiento=expediente.fechaNacimiento,
                idGenero=expediente.IdGenero,
                UrlImagen= expediente.UrlImagen,
                NoISSS=expediente.NoISSS
            };
            _context.InformacionPersonales.Add(informacionPersonal);
            _context.SaveChanges();

            clsInformacionAdicional informacionAdicional = new clsInformacionAdicional 
            {
                lugarNacimiento=expediente.LugarNacimiento,
                telefonoDomicilio=expediente.telefonoDomicilio,
                telefonoOficina=expediente.telefonoOficina,
                correo=expediente.correo,
                responsableA=expediente.responsableA,
                idEstadoCivil=expediente.IdEstadoCivil,
                conyugue=expediente.conyugue,
                fechaIngreso=DateTime.Now,
            };
            _context.InformacionAdicionales.Add(informacionAdicional);
            _context.SaveChanges();

            clsExploracionFisica exploracionFisica = new clsExploracionFisica
            {
                altura=expediente.altura,
                peso=expediente.peso,
                idTipoPiel=expediente.IdTipoPiel,
                marcaNaci=expediente.marcaNaci,
                idColorCabello=expediente.IdColorCabello,
                OcupaLentes=expediente.ocupaLentes,
                PresentaDisca=expediente.presentaDisc,
                ProblemaAuditivo=expediente.problemaAuditivo
            };
            _context.ExploracionesFisicas.Add(exploracionFisica);
            _context.SaveChanges();

            var medicoGrl = new GlMedicoGrl {
                nombre=expediente.medicoGrl,
                direccionMedico=expediente.medicoGrl,
                telefono=expediente.telefonoMedico
            };
            _context.medicos.Add(medicoGrl);
            _context.SaveChanges();

            var seguro = new GlComSeguro
            {
                nombre="Seguro "+generarNumExpediente(),
                NoPoliza=expediente.poliza
            };

            _context.seguros.Add(seguro);
            _context.SaveChanges();


            clsHistorialMedico historialMedico = new clsHistorialMedico
            {
                idMedicoGrl=medicoGrl.idMedicoGrl,
                dentistaFamilia=expediente.dentistaFamilia,
                idHospital=expediente.IdHospital,
                idSeguro=seguro.idSeguro                

            };
            _context.HistorialMedicos.Add(historialMedico);
            _context.SaveChanges();

            //creamos expediente
            clsExpediente clsExpediente = new clsExpediente 
            {
                idInformacionPersonal=informacionPersonal.idInformacionPersonal,
                idInformacionAdicional=informacionAdicional.idInformacionAdicional,
                idExploracionFisica=exploracionFisica.idExploracionFisica,
                idHistorialMedico=historialMedico.idHistorialMedico,
                fechaCreacion=DateTime.Now
            };

            _context.Expedientes.Add(clsExpediente);
            //Guardamos el expediente
            _context.SaveChanges();

            //Se agrego el modelo de paciente, para guardar de forma predifinida el expediente 
            //Creamos la instancia de paciente, con el expediente, recien creado
            clsPaciente paciente = new clsPaciente
            {
                idExpediente = clsExpediente.idExpediente,
                isPaciente=true
            };
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();

            //obtenemos el idExpediente para guardar alergias

            //llenamos las alergias del expediente
            foreach (pivoteAlergiaExp ale in expediente.alergias)
            {
                var a = new pivoteAlergiaExp {
                    idAlergia=ale.idAlergia,
                    idExpediente=clsExpediente.idExpediente
                };
                _context.pivoteAlergiaExps.Add(a);
                _context.SaveChanges();
            }

            //llenamos las incapacidades del expediente
            foreach (var inca in expediente.incapacidades)
            {
                var inc = new pivoteIncapacidadExpediente
                {
                    idExpediente=clsExpediente.idExpediente,
                    idTipoIncapacidad=inca.idTipoIncapacidad
                };
                _context.pivoteIncapacidadExpedientes.Add(inc);
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
                    message="Problemas al guardar expediente, verifique"
                });
            }
            return Ok(new {
                ok=true,
                message="Se ha guardado el expediente de forma correcta"
            });
        }


        //PUT: api/Expediente/Actualizar
        [HttpPut("[action]")]
        public async Task<ActionResult<clsExpediente>> Actualizar([FromBody] CrearVmExpediente expediente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (expediente.idExpediente<=0)
            {
                return BadRequest();
            }
            var expe = await _context.Expedientes.FirstOrDefaultAsync(e => e.idExpediente == expediente.idExpediente);
            if (expe == null)
            {
                return NotFound();
            }
            expe.fechaCreacion = DateTime.Now;
            var infoPer = await _context.InformacionPersonales.FirstOrDefaultAsync(e => e.idInformacionPersonal == expe.idInformacionPersonal);
            infoPer.nombre = expediente.nombrePaciente;
            infoPer.apellido = expediente.apellidoPaciente;
            infoPer.domicilio = expediente.domicilioPaciente;
            infoPer.fechaNacimiento = expediente.fechaNacimiento;
            infoPer.idGenero = expediente.IdGenero;
            //infoPer.UrlImagen = expediente.UrlImagen;
            //_context.SaveChanges();

            var inforAdi = await _context.InformacionAdicionales.FirstOrDefaultAsync(e => e.idInformacionAdicional == expe.idInformacionAdicional);
            inforAdi.lugarNacimiento = expediente.LugarNacimiento;
            inforAdi.telefonoDomicilio = expediente.telefonoDomicilio;
            inforAdi.telefonoOficina = expediente.telefonoOficina;
            inforAdi.responsableA = expediente.responsableA;
            //_context.SaveChanges();

            var expFi = await _context.ExploracionesFisicas.FirstOrDefaultAsync(e => e.idExploracionFisica == expe.idExploracionFisica);
            expFi.altura = expediente.altura;
            expFi.peso = expediente.peso;
            expFi.OcupaLentes = expediente.ocupaLentes;
            expFi.ProblemaAuditivo = expediente.problemaAuditivo;
            expFi.idTipoPiel = _context.TipoPiels.Where(t => t.tipo.Contains(expediente.TipoPiel)).Select(t => t.idTipoPiel).FirstOrDefault();
            expFi.idColorCabello = _context.ColorCabellos.Where(c=>c.colorCabello.Contains(expediente.ColorCabello)).Select(c=>c.idColorCabello).FirstOrDefault();
           //_context.SaveChanges();

            //var hisM = await _context.HistorialMedicos.FirstOrDefaultAsync(e => e.idHistorialMedico == expe.idHistorialMedico);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al actualizar expediente, verifique "+e.Message
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha actualizado el expediente de forma correcta"
            });
        }


        [HttpPut("[action]/{idExpediente}")]
        public async Task<ActionResult<clsExpediente>> Eliminar([FromRoute] int idExpediente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (idExpediente <= 0)
            {
                return BadRequest();
            }
            var expe = await _context.Expedientes.FirstOrDefaultAsync(e => e.idExpediente == idExpediente);
            if (expe == null)
            {
                return NotFound();
            }
            expe.isActive = 0;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                return BadRequest(new
                {
                    ok = false,
                    message = "Problemas al eliminar expediente, verifique " + e.Message
                });
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha eliminado el expediente de forma correcta"
            });
        }

        private string createTitle()
        {
            String title = "Crear expediente No.";
            var ultimo = _context.Expedientes.OrderByDescending(x => x.idExpediente).First();
            return title+ultimo.idExpediente.ToString();
        }

        private List<clsIncapacidad> obtenerIncapacidades(int idExpediente)
        
        {
            var incaExp = _context.pivoteIncapacidadExpedientes
                .Where(e=>e.idExpediente==idExpediente)
                .ToList();
            var incapacidades = _context.Incapacidades.ToList();
            var expediente = _context.Expedientes
                .Where(e=>e.idExpediente==idExpediente)
                .ToList();
            
            var query = from ie in incaExp
                        join i in incapacidades on ie.idTipoIncapacidad equals i.idTipoIncapacidad
                        join e in expediente on ie.idExpediente equals e.idExpediente
                        select new clsIncapacidad {
                            estado=i.estado,
                            nombre=i.nombre,
                            tipo=i.tipo,
                            isListaAlergia=i.isListaAlergia,
                            isRestricciones=i.isRestricciones,
                            idTipoIncapacidad=ie.idTipoIncapacidad
                        };
            
            return query.ToList();
        }

        private List<clsAlergia> obtenerAlergias(int idExpediente)
        {
            var alergiasExp = _context.pivoteAlergiaExps
                .Where(e=>e.idExpediente==idExpediente)
                .ToList();
            var alergias = _context.Alergias.ToList();
            var expediente = _context.Expedientes.ToList();
            var query = from ae in alergiasExp
                        join a in alergias on ae.idAlergia equals a.idAlergia
                        join e in expediente on ae.idExpediente equals e.idExpediente
                        select new clsAlergia {
                            idAlergia=ae.idAlergia,
                            estado=a.estado,
                            nombre=a.nombre
                        };
            return query.ToList();
        }

        private string generarNumExpediente()
        {
            Random random = new Random();
            return "No." + random.Next(0, 100);
        }
    }
}

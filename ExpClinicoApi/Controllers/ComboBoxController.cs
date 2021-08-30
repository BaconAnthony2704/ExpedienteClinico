using ExpClinicoApi.Models.Global;
using ExpClinicoApi.ViewModels;
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
    public class ComboBoxController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public ComboBoxController(DbContextSystem context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<GlEstadoCivil>> ListarEstadoCivil()
        {
            var estadoc = await _context.EstadoCivils.ToListAsync();
            return estadoc.Select(e => new GlEstadoCivil
            {
                idEstadoCivil = e.idEstadoCivil,
                estado = e.estado
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GlGenero>> ListarGenero()
        {
            var genero = await _context.generos.ToListAsync();
            return genero.Select(g => new GlGenero
            {
                idGenero = g.idGenero,
                tipo = g.tipo
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GlTipoPiel>> ListarTipoPiel()
        {
            var tipoPiel = await _context.TipoPiels.ToListAsync();
            return tipoPiel.Select(g => new GlTipoPiel
            {
                idTipoPiel=g.idTipoPiel,
                tipo = g.tipo
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GlColorCabello>> ListarColorCabello()
        {
            var colorCabellos = await _context.ColorCabellos.ToListAsync();
            return colorCabellos.Select(g => new GlColorCabello
            {
                idColorCabello=g.idColorCabello,
                colorCabello=g.colorCabello
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GlHospital>> ListarHospitales()
        {
            var hospital = await _context.Hospitales.ToListAsync();
            return hospital.Select(g => new GlHospital
            {
                idHospital=g.idHospital,
                nombre=g.nombre,
                direccion=g.direccion
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<GlComSeguro>> ListarSeguros()
        {
            var seguros = await _context.seguros.ToListAsync();
            return seguros.Select(g => new GlComSeguro
            {
                idSeguro=g.idSeguro,
                nombre=g.nombre,
                NoPoliza=g.NoPoliza
            });
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmMedicoGrl>> ListarMedico()
        {
            var medicos = await _context.medicos.ToListAsync();
            return medicos.Select(g => new vmMedicoGrl
            {
                idMedicoGrl=g.idMedicoGrl,
                nombre=g.nombre
            });
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmPaciente>> ListarPaciente()
        {
            var pacientes = await _context.Pacientes
                .Include(e=>e.expediente.informacionPersonal)
                .ToListAsync();
            return pacientes.Select(g => new vmPaciente
            {
                idPaciente=g.idPaciente,
                nombre=g.expediente.informacionPersonal.nombre+", "+g.expediente.informacionPersonal.apellido
            });
        }



    }
}

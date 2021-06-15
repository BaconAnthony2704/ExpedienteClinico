using ExpClinicoApi.Models;
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
    public class IncapacidadController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public IncapacidadController(DbContextSystem context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<clsIncapacidad>> Listar()
        {
            var inca = await _context.Incapacidades.ToListAsync();
            return inca.Select(i => new clsIncapacidad 
            {
                estado=i.estado,
                idTipoIncapacidad=i.idTipoIncapacidad,
                isListaAlergia=i.isListaAlergia,
                isRestricciones=i.isRestricciones,
                nombre=i.nombre,
                tipo=i.tipo
            });
        }
    }
}

using ExpClinicoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlergiaController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public AlergiaController(DbContextSystem context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<clsAlergia>> Listar()
        {
            var alergia = await _context.Alergias.ToListAsync();
            return alergia.Select(a => new clsAlergia 
            {
                estado=a.estado,
                idAlergia=a.idAlergia,
                nombre=a.nombre
            });
        }
    }
}

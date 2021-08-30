using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public PacienteController(DbContextSystem context)
        {
            _context = context;
        }

        //Get api/Paciente/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<clsExpediente>>> Listar()
        {
            var paciente = await _context.Expedientes.ToListAsync();
            
            return paciente;
        }


    }
}

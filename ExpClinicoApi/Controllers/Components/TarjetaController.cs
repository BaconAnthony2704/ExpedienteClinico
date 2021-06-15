using ExpClinicoApi.ViewModels.Componets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpClinicoApi.Controllers.Components
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public TarjetaController(DbContextSystem context)
        {
            _context = context;
        }
        // GET: api/<TarjetaController>
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmTarjeta>> Listar()
        {
            var tarjeta =await  _context.Tarjetas.ToListAsync();
            return tarjeta.Select(t=>new vmTarjeta
            {
                idTarjeta=t.idTarjeta,
                nombre=t.nombre,
                descripcion=t.descripcion,
                color=t.color,
                estado=t.estado,
                icono=t.icono,
                ruta=t.ruta,
                urlimagen=t.urlimagen
            });
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

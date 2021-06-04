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
    public class AlbumController : ControllerBase
    {
        private readonly DbContextSystem _context;
        public AlbumController(DbContextSystem context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Album>> Listar()
        {
            var album = await _context.Albunes.ToListAsync();
            return album.Select(a=> new Album {
                Name=a.Name,
                Genre=a.Genre,
                ArtistaName=a.ArtistaName,
                Price=a.Price
            });
        }
        //[HttpPost("[action]")]
        //public async Task<ActionResult<Album>> Crear([FromBody] Album album)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //    }
        //}
    }
}

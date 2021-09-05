using ExpClinicoApi.Helpers;
using ExpClinicoApi.Models;
using ExpClinicoApi.ViewModels;
using ExpClinicoApi.ViewModels.Crear;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbContextSystem _context;
        
        public LoginController(DbContextSystem context)
        {
            _context = context;
        }



        //GET: api/Login/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<vmLogin>> Listar()
        {
            var login = await _context.Logins.ToListAsync();
            return login.Select(lo => new vmLogin
            {
                idUser=lo.idUser,
                isactive=lo.isactive,
                modified=lo.modified,
                name=lo.name,
                password=lo.password,
                username=lo.username
            });

        }

        //GET: api/Login/Obtener
        [HttpPost("[action]")]
        public async Task<ActionResult<vmLogin>> Obtener([FromBody] vmGetLogin GetLogin)
        {
            
            var pass= CypherHelper.Encrypt(GetLogin.password);
            var login = await _context.Logins.ToListAsync();
            var lo=login.Select(lo => new vmLogin
            {
                idUser = lo.idUser,
                isactive = lo.isactive,
                modified = lo.modified,
                name = lo.name,
                password = lo.password,
                username = lo.username
            }).Where(c=>
            c.username.Contains(GetLogin.username) && 
            c.password.Contains(pass)).FirstOrDefault();
            if (lo!=null)
            {
                return Ok(
                    new {
                        ok=true,
                        obj=lo,
                        msg="Bienvenido "+lo.name
                    });
            }
            else
            {
                return BadRequest(
                    new {
                        ok=false,
                        obj=lo,
                        msg="No existe el usuario"
                    });
            }

            


        }

        [HttpPost("[action]")]
        public async Task<ActionResult<vmLogin>> Registrar([FromBody] CrearLogin login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_context.Logins.Select(lo => lo.username).Where(c => c.Contains(login.username)).Count() == 1)
            {
                return BadRequest(
                    new {
                        ok=false,
                        obj="El usuario ya existe"
                    }
                    );
            }

            byte[] clavebyte = new PasswordDeriveBytes(login.password, null).GetBytes(32);
            clsLoginUserModel clsLogin = new clsLoginUserModel
            {
                isactive = true,
                modified = DateTime.Now,
                name = login.name,
                password = CypherHelper.Encrypt(login.password),
                username=login.username
            };

            try
            {
                _context.Logins.Add(clsLogin);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(
                new {
                    ok=true,
                    obj=clsLogin
                }
                );

        }

        
    }

}

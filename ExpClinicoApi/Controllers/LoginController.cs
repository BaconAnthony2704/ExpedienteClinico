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
            c.isactive==true &&
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
        [HttpPut("[action]/{IdUser}")]
        public async Task<ActionResult<vmLogin>> Editar([FromBody] CrearLogin login,int IdUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _context.Logins.FirstOrDefault(l => l.idUser == IdUser);
            if (user != null)
            {
                user.password = CypherHelper.Encrypt(login.password);
                user.name = login.name;
                user.username = login.username;
                   
            }
            

            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(
                new
                {
                    ok = true,
                    obj = "Se ha actualizado el usuario"
                }
                );

        }

        [HttpPut("[action]/{IdUser}")]
        public async Task<ActionResult<vmLogin>> Desactivar([FromRoute] int IdUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_context.Logins.Select(lo => lo.idUser).Where(c => c.Equals(IdUser)).Count() == 1)
            {
                var user = _context.Logins.ToList().FirstOrDefault(l=>l.idUser==IdUser);
                user.isactive = false;
            }

            
            
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(
                new
                {
                    ok = true,
                    obj = "El usuario se ha desactivado"
                }
                );

        }

        [HttpPut("[action]/{IdUser}")]
        public async Task<ActionResult<vmLogin>> Activar([FromRoute] int IdUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_context.Logins.Select(lo => lo.idUser).Where(c => c.Equals(IdUser)).Count() == 1)
            {
                var user = _context.Logins.ToList().FirstOrDefault(l => l.idUser == IdUser);
                user.isactive = true;
            }



            try
            {

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return Ok(
                new
                {
                    ok = true,
                    obj = "El usuario se ha activado"
                }
                );

        }

        // POST api/Login/CrearToJson
        [HttpPost("[action]")]
        public async Task<ActionResult<clsLoginUserModel>> Creartojson([FromBody] List<CrearUser> listUser)
        {
            //List<CrearUser> nuevaListaFiltrada = new List<CrearUser>();
            //var listaUsr = await _context.Logins.ToListAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new
                    {
                        ok = false,
                        msg = "El modelo no es valido"
                    });
            }

            //Llenar la tabla concepto
            foreach (CrearUser usrs in listUser)
            {
                var u = new clsLoginUserModel
                {
                    isactive = true,
                    modified = DateTime.Now,
                    username = usrs.username,
                    name = usrs.name,
                    password = CypherHelper.Encrypt(usrs.password)
                };
                _context.Logins.Add(u);
            }
            try
            {

                await _context.SaveChangesAsync();
                return Ok(
                    new
                    {
                        ok = true,
                        msg = "Se ha ingresado correctamente"
                    }
                );
            }
            catch (Exception)
            {

                return BadRequest(new { ok = false, msg = "Problemas en la insersion" });
            }
        }


    }

}

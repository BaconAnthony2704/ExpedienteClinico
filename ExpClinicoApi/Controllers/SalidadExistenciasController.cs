using ExpClinicoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpClinicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidadExistenciasController : ControllerBase
    {
        private readonly DbContextSystem _context;

        public SalidadExistenciasController(DbContextSystem context)
        {
            _context = context;
        }

        // GET: api/<SalidadExistenciasController>
        //debo listar la existencia
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        /*
        // GET api/<SalidadExistenciasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST api/<SalidadExistenciasController>

        //modificar para que acepte una lista de medicamentos

        /* 
          pasos: 
          1- crear el objeto recetaMedicamento (la receta lleva el id del paciente)
          2-obtener ese id para relacionar las demas cosas
          3-crear el objeto transaccion medicamento(cada item de medicamento es un objeto con el id de 
          medicamento y el idde la receta) 
          */

        [HttpPost]
        public async Task<ActionResult<Models.clsTransacionMedicamento>> Post([FromBody] List<clsTransacionMedicamento> listaMedicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var fecha = DateTime.Now;
            // 1 - crear el objeto recetaMedicamento(la receta lleva el id del paciente)
            clsRecetaMedicamento receta = new clsRecetaMedicamento();
            receta.fecha = fecha;
            //receta.idReceta = 1;
            //receta = 1;
            

            //receta.idReceta = 1090;

            await _context.RecetaMedicamento.AddAsync(receta);
            await _context.SaveChangesAsync();

            //var idreceta = _context.RecetaMedicamento.Last();
            foreach (var item in listaMedicamento)
            {
                //creamos una transaccion por cada miembro de la lista
                clsTransacionMedicamento tr = new clsTransacionMedicamento();
                tr.idReceta = receta.idReceta;
                tr.idMedicamento = item.idMedicamento;
                tr.cantidad = item.cantidad;
                tr.tipo_transaccion = 1;


                var medicamento = _context.Medicamento.Where(m => m.IDMEDICAMENTO == tr.idMedicamento).FirstOrDefault();
                var existencia_medicamento = medicamento.EXISTENCIA;
                
                //actualizamos la existencia
                var nueva_Existencia = existencia_medicamento - tr.cantidad;

                medicamento.EXISTENCIA = nueva_Existencia;
                _context.Medicamento.Update(medicamento);

                 //_context.Medicamento.Add(medicamento_update);
                //_context.SaveChanges();
                await _context.TransacionMedicamento.AddAsync(tr);
                await _context.SaveChangesAsync();
                
                
            }
            return Ok(new
            {
                ok = true,
                message = "Se ha creado el Tipo Consulta de forma correcta"
            });

        }

        // PUT api/<SalidadExistenciasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalidadExistenciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

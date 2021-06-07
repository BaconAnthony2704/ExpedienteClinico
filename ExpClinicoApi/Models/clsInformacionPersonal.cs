using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsInformacionPersonal
    {
        public int idInformacionPersonal { get; set; }
        public string titulo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public DateTime fechaNacimiento { get; set; }
        [ForeignKey("idGenero")]
        public GlGenero genero { get; set; }
        public string NoISSS { get; set; }
        public string UrlImagen { get; set; }

        //atributos opcionales
        public int? idGenero { get; set; }
    }

    
}

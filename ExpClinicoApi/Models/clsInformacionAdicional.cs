using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsInformacionAdicional
    {
        public int id { get; set; }
        public string lugarNacimiento { get; set; }
        public string telefonoDomicilio { get; set; }
        public string telefonoOficina { get; set; }
        public string correo { get; set; }
        public string responsableA { get; set; }
        [ForeignKey("idEstadoCivil")]
        public GlEstadoCivil estadoCivil { get; set; }
        public string conyugue { get; set; }
        public bool NvoPaciente { get; set; }
        public DateTime fechaIngreso { get; set; }

        //atributos opcionales
        public int? idEstadoCivil { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsCita
    {
        public int idCita { get; set; }

        [ForeignKey("idPaciente")]
        public clsPaciente paciente { get; set; }
        //public String nombrePaciente { get; set; }
        public DateTime fechaIngreso { get; set; }

        //atributos opcionales
        public int? idPaciente { get; set; }
    }
}

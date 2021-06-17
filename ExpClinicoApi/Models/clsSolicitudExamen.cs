using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsSolicitudExamen
    {
        public int idSolicitudExamen { get; set; }
        public DateTime fechaIngreso { get; set; }

        [ForeignKey("idPaciente")]
        public clsPaciente paciente { get; set; }

        [ForeignKey("idMedicoGrl")]
        public GlMedicoGrl medico { get; set; }

        //atributos opcionales
        public int? idPaciente { get; set; }
        public int? idMedicoGrl { get; set; }
    }
}

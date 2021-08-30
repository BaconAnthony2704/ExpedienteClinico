using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsConsulta
    {
        
        public int idConsulta { get; set; }

        [ForeignKey("idPaciente")]
        public clsPaciente paciente { get; set; }

        [ForeignKey("idHistorialMedico")]
        public clsHistorialMedico historialMedico { get; set; }

        [ForeignKey("idTipoConsulta")]
        public clsTipoConsulta tipoConsulta { get; set; }

        public DateTime fechaConsulta { get; set; }


    }
}

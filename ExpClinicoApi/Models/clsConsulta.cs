using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblconsulta")]
    public class clsConsulta
    {
        [Key]
        public int idConsulta { get; set; }

        [ForeignKey("idPaciente")]
        public clsPaciente paciente { get; set; }

        [ForeignKey("idHistorialMedico")]
        public clsHistorialMedico historialMedico { get; set; }

        [ForeignKey("idTipoConsulta")]
        public clsTipoConsulta tipoConsulta { get; set; }

        public DateTime fechaConsulta { get; set; }


        //otros atributos
        public int? idPaciente { get; set; }
        public int? idHistorialMedico { get; set; }
        public int? idTipoConsulta { get; set; }


    }
}

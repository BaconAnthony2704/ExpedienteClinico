using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpClinicoApi.Models
{
    public class clsRecetaMedicamento
    {
        [Key]
        public int idReceta { get; set; }
        public DateTime fecha { get; set; }
        
        //[ForeignKey("idPaciente")]
        //public int paciente { get; set; }

    }
}
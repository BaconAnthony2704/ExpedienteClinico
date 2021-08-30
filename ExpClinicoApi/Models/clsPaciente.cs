using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsPaciente
    {
        public int idPaciente { get; set; }

        [ForeignKey("idExpediente")]
        public clsExpediente expediente { get; set; }

        public bool isPaciente { get; set; }

        //atributos opcionales
        public int idExpediente { get; set; }
    }
}

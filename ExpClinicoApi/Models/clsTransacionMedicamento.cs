using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsTransacionMedicamento
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("codigo")]
        public clsMedicamento idMedicamento { get; set; }
        
        [ForeignKey("idRecetaMedicamento")]
        public clsRecetaMedicamento idReceta{ get; set; }
    public int tipoTransaccion { get; set; }   //1- entrada , 2-salidad
        public int cantidad { get; set; }
    }
}

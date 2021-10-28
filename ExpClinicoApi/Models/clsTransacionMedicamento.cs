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
        public int idTransaccionMedicamento { get; set; }
        [ForeignKey("idMedicamento")]
        public clsMedicamento Medicamento { get; set; }
        
        [ForeignKey("idReceta")]
        public clsRecetaMedicamento Receta{ get; set; }

        public int idReceta { get; set; }
        public int idMedicamento { get; set; }
        public int tipo_transaccion { get; set; }   //1- entrada , 2-salidad
        public int cantidad { get; set; }
    }
}

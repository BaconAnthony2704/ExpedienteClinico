using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblanticipo")]
    public class clsAnticipo
    {
        [Key]
        public int idAnticipo { get; set; }
        public string descripcion { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idEmpleado")]
        public clsEmpleado empleado { get; set; }

        //otros atributos
        public int? idEmpleado { get; set; }
    }
}

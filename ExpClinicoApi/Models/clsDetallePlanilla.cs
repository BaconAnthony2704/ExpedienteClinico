using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tbldetalleplanilla")]
    public class clsDetallePlanilla
    {
        [Key]
        public int idDetallePlanilla {get; set;}
        [ForeignKey("idEmpleado")]
        public int empleado { get; set; }
        [ForeignKey("idPlanilla")]
        public int planila { get; set; }

        //otros atributos
        public int? idEmpleado { get; set; }
        //otros atributos
        public int? idPlanilla { get; set; }
    }
}

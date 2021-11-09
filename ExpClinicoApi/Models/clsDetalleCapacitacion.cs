using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tbldetallecapacitacion")]
    public class clsDetalleCapacitacion
    {
        [Key]
        public int idDetalleCapacitacion { get; set; }
        [ForeignKey("idEmpleado")]
        public clsEmpleado empleado { get; set; }
        [ForeignKey("idCapacitacion")]
        public clsCapacitacion capacitacion { get; set; }

        //otros atributos
        public int? idEmpleado { get; set; }
        public int? idCapacitacion { get; set; }
    }
}

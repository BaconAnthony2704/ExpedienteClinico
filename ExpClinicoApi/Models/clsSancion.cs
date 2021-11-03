using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblsancion")]
    public class clsSancion
    {
        [Key]
        public int idSancion { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idEmpleado")]
        public clsEmpleado empleado { get; set; }


        public int? idEmpleado { get; set; }
    }
}

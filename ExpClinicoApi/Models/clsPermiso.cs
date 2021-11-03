using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblpermiso")]
    public class clsPermiso
    {
        [Key]
        public int idPermiso { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idEmpleado")]
        public clsEmpleado empleado { get; set; }

        //otros atributos
        public int? idEmpleado { get; set; }
    }
}

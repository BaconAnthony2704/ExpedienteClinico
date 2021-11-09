using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblasistencialaboral")]
    public class clsAsistenciaLaboral
    {
        [Key]
        public int idAsistenciaLaboral { get; set; }
        public Boolean sePresento { get; set; }
        public Boolean conPermiso { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idPermiso")]
        public clsPermiso permiso { get; set; }
        [ForeignKey("idEmpleado")]
        public clsEmpleado empleado { get; set; }

        //otros atributos
        public int? idPermiso { get; set; }
        public int? idEmpleado { get; set; }
    }
}

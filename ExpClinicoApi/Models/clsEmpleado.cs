using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblempleado")]
    public class clsEmpleado
    {
        [Key]
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public int dui { get; set; }
        public int nit { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaSalida { get; set; }
        public string titulo { get; set; }
        public string cargo { get; set; }
        public float sueldo { get; set; }
    }
}

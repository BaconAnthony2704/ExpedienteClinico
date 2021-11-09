using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblplanilla")]
    public class clsPlanilla
    {
        [Key]
        public int idPlanilla { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public Boolean activo { get; set; }
        public float totalSalario { get; set; }
        public float totalAnticipo { get; set; }
        public float totalDescuento { get; set; }
        public float isssTotal { get; set; }
        public float totalAfp { get; set; }
        public float totalDescuentos { get; set; }
        public float totalPagar { get; set; }
    }
}

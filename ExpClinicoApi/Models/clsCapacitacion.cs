using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblcapacitacion")]
    public class clsCapacitacion
    {
        [Key]
        public int idCapacitacion { get; set; }
        public string descripcion { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpClinicoApi.Models
{
    [Table("tblreceta")]
    public class clsReceta
    {
        [Key]
        public int idReceta { get; set; }

        public String descripcionReceta { get; set; }
    }
}

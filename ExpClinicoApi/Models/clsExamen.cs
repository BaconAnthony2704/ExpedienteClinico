using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblexamen")]
    public class clsExamen
    {
        [Key]
        public int idExamen { get; set; }
        public string nombre { get; set; }

        public string tipoExamen { get; set; }
    }
}

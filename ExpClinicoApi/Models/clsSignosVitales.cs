using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpClinicoApi.Models
{
    [Table("tblsignosvitales")]
    public class clsSignosVitales
    {
        [Key]
        public int idSignosVitales { get; set; }
        public string presionArterial { get; set; }
        public string talla { get; set; }
        public int peso { get; set; }
        public int temperatura { get; set; }
        public int frecuenciaCardiaca { get; set; }
        public int frecuenciaRespiratoria { get; set; }

    }
}

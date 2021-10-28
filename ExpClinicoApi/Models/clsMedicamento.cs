using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsMedicamento
    {

        [Key]
        //[Column("IDMEDICAMENTO")]
        public int IDMEDICAMENTO { get; set; }
        
        public string NOMBRE { get; set; }
        
        public string TIPO { get; set; }

        public int EXISTENCIA { get; set; }
        public string DESCRIPCION { get; set; }

    }
}

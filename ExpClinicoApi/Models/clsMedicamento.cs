using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsMedicamento
    {

        [Key]
        public int idMedicamento { get; set; }
        
        public string nombre { get; set; }
        public string tipo { get; set; }

        public int existencia { get; set; }
        public string descripcion { get; set; }

    }
}

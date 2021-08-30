using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpClinicoApi.Models
{
    public class clsReceta
    {
        public int idReceta { get; set; }

        public String descripcionReceta { get; set; }
    }
}

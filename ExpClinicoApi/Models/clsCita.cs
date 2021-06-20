using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsCita
    {
        public int id { get; set; }

        public String nombrePaciente { get; set; }
        public DateTime dateTime { get; set; }
    }
}

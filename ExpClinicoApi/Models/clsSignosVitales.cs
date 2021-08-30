using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsSignosVitales
    {
        public int idSignosVitales { get; set; }
        public string presionArterial { get; set; }
        public string talla { get; set; }
        public int peso { get; set; }
        public int temperatura { get; set; }
        public int frecuenciaCardiaca { get; set; }
        public int frecuenciaRespiratoria { get; set; }

    }
}

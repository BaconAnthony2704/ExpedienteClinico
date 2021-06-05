using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsDetalleSolicitudExamen
    {
        public int idclsSolicitudExamen { get; set; }
        public int idclsExamen { get; set; }

        public clsSolicitudExamen solicitudExamen { get; set; }
        public clsExamen examen { get; set; } 

    }
}

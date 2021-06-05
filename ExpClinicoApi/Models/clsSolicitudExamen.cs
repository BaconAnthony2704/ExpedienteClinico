using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsSolicitudExamen
    {
        public int idSolicitudExamen { get; set; }
        public int idclsExpediente { get; set; }
        public int idGlMedicoGrl { get; set; }
        public DateTime date { get; set; }

    }
}

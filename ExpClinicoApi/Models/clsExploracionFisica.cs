using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsExploracionFisica
    {
        public int id { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public GlTipoPiel tipoPiel { get; set; }
        public string marcaNaci { get; set; }
        public GlColorCabello colorCabello { get; set; }
        public bool OcupaLentes { get; set; }
        public bool PresentaDisca { get; set; }
        public bool ProblemaAuditivo { get; set; }
    }
}

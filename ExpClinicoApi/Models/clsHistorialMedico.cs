using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsHistorialMedico
    {
        public GlMedicoGrl medicoGrl { get; set; }
        public string dentistaFamilia { get; set; }
        public DateTime ultimaVacuna { get; set; }
        public GlHospital hospital { get; set; }
        public GlComSeguro seguro { get; set; }
    }
}

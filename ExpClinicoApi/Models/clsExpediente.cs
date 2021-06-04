using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsExpediente
    {
        public int idExpediente { get; set; }
        public int? idInformacionPersonal { get; set; }
        public int? idInformacionAdicional { get; set; }
        public int? idExploracionFisica { get; set; }
        public int? idHistoralMedico { get; set; }
        public int? idAlergias { get; set; }
        public int? idIncapacidad { get; set; }

        public clsInformacionPersonal informacionPersonal { get; set; }
        public clsInformacionAdicional informacionAdicional { get; set; }
        public clsExploracionFisica exploracionFisica { get; set; }
        public clsHistorialMedico historialMedico { get; set; }
        public List<clsAlergia> alergias { get; set; }
        public clsIncapacidad incapacidad { get; set; }
    }
}

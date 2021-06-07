using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsExpediente
    {
        public int idExpediente { get; set; }
        //public int? idInformacionPersonal { get; set; }
        //public int? idInformacionAdicional { get; set; }
        //public int? idExploracionFisica { get; set; }
        //public int? idHistoralMedico { get; set; }
        //public int? idAlergias { get; set; }
        //public int? idIncapacidad { get; set; }

        [ForeignKey("idInformacionPersonal")]
        public clsInformacionPersonal informacionPersonal { get; set; }

        [ForeignKey("idInformacionAdicional")]
        public clsInformacionAdicional informacionAdicional { get; set; }

        [ForeignKey("idExploracionFisica")]
        public clsExploracionFisica exploracionFisica { get; set; }

        [ForeignKey("idHistorialMedico")]
        public clsHistorialMedico historialMedico { get; set; }

        //[ForeignKey("idAlergia")]
        //public List<clsAlergia> alergias { get; set; }

        //[ForeignKey("idTipoIncapacidad")]
        //public List<clsIncapacidad> incapacidades { get; set; }

        public DateTime fechaCreacion { get; set; }


        //atributos opcionales
        [Column("idInformacionPersonal")]
        public int? idInformacionPersonal { get; set; }
        public int? idInformacionAdicional { get; set; }
        public int? idExploracionFisica { get; set; }

        //[Column("idHisto")]
        public int? idHistorialMedico { get; set; }
        //public int? idAlergias { get; set; }
        //public int? idIncapacidad { get; set; }
    }
}

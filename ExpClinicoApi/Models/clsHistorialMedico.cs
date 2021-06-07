using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsHistorialMedico
    {
        public int  idHistorialMedico { get; set; }
        [ForeignKey("idMedicoGrl")]
        public GlMedicoGrl medicoGrl { get; set; }
        public string dentistaFamilia { get; set; }
        public DateTime ultimaVacuna { get; set; }
        [ForeignKey("idHospital")]
        public GlHospital hospital { get; set; }
        [ForeignKey("idSeguro")]
        public GlComSeguro seguro { get; set; }


        //atributos opcionales
        public int? idMedicoGrl { get; set; }
        public int? idHospital { get; set; }
        public int? idSeguro { get; set; }
    }
}

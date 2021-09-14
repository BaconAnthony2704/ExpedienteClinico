using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblhistorialmedico")]
    public class clsHistorialMedico
    {
        [Key]
        public int  idHistorialMedico { get; set; }
        
        [ForeignKey("idMedicoGrl")]
        public GlMedicoGrl medicoGrl { get; set; }
        
        public string dentistaFamilia { get; set; }
        
        public DateTime ultimaVacuna { get; set; }
        
        [ForeignKey("idHospital")]
        public GlHospital hospital { get; set; }
        
        [ForeignKey("idSeguro")]
        public GlComSeguro seguro { get; set; }

        [ForeignKey("idReceta")]
        public clsReceta receta { get; set; }

        [ForeignKey("idSignosVitales")]
        public clsSignosVitales signosVitales { get; set; }
        public String consultaPor { get; set; }

        public String enfermedadActual { get; set; }

        public String antecedentesPersonales { get; set; }

        public String antecedentesFamiliares { get; set; }

        public String examenesClinicos { get; set; }

        public String exploracionFisica { get; set; }

        public String diagnosticoPrincipal { get; set; }

        public String otroDiagnostico { get; set; }

        public String tratamiento { get; set; }

        public String observaciones { get; set; }


        //atributos opcionales
        public int? idmedicoGrl { get; set; }
        public int? idHospital { get; set; }
        public int? idSeguro { get; set; }
        public int? idSignosVitales { get; set; }
        public int? idReceta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExpClinicoApi.Models;

namespace ExpClinicoApi.ViewModels.Crear
{
    [Table("tblHistorialMedico")]
    public class CrearVmHistorialMedico
    {
        [Key]
        public int idHistorialMedico { get; set; }//
        public string dentistaFamilia { get; set; }//

        public String consultaPor { get; set; }//

        public String enfermedadActual { get; set; }//

        public String antecedentesPersonales { get; set; }//

        public String antecedentesFamiliares { get; set; }//

        public String examenesClinicos { get; set; }//

        public String exploracionFisica { get; set; }//

        public String diagnosticoPrincipal { get; set; }//

        public String otroDiagnostico { get; set; }//

        public String tratamiento { get; set; }//

        public String observaciones { get; set; }//
        public DateTime ultimaVacuna { get; set; }//


        //atributos para los id de otras tablas
        public int? idmedicoGrl { get; set; }//
        public int? idHospital { get; set; }//
        public int? idSeguro { get; set; }//
        public int? idSignosVitales { get; set; }//
        public int? idReceta { get; set; }//
        public int? idSolicitudExamen { get; set; }//
    }
}

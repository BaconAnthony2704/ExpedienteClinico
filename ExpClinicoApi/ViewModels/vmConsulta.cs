using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmConsulta
    {
        public int idExpediente { get; set;} 
        public string nombrePaciente { get; set;}
        public int edad { get; set;}
        public string sexo { get; set;}
        public int telefono { get; set;}
        public string estadoCivil { get; set; }
        public string doctor { get; set; }
        public string tipoConsulta { get; set; }
        public DateTime fecha { get; set; }
        public string consultaPor { get; set; }
        public string enfermedadActual { get; set; }
        public string antecedentesPersonales { get; set; }
        public string antecedentesFamiliares { get; set; }
        public string examenesClinicos { get; set; }
        public string exploracionFisica { get; set; }
        public string diagnosticoPrincipal { get; set; }
        public string otroDiagnostico { get; set; }
        public string tratamiento { get; set; }
        public string observaciones { get; set; }
        public int idConsulta { get; set; }
        public int idReceta { get; set; }
        public string descripcionReceta { get; set; }
        public int idExameneClinico { get; set; }
        public string descripcionExamenClinico { get; set; }
        public int presionArterial { get; set; }
        public int talla { get; set; }
        public int peso { get; set; }
        public int temperatura { get; set; }
        public int frecuenciaCardiaca { get; set; }
        public int frecuenciaRespiratoria { get; set; }
        public int idPaciente { get; set; }
        public int idMedicoGrl { get; set; }
    }
}

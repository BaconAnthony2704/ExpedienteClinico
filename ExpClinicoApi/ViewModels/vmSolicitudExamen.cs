using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmSolicitudExamen
    {
        public int idSolicitudExamen { get; set; }
        public DateTime fechaIngreso { get; set; }

        public string paciente { get; set; }

        public string medico { get; set; }

        //atributos opcionales
        public int? idPaciente { get; set; }
        public int? idMedicoGrl { get; set; }

        public List<vmDetalleSolicitudExamen> DetalleSolicitudExamenes { get; set; }
    }
}

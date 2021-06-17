using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Crear
{
    public class CrearVmSolicitudExamen
    {
        public int idSolicitudExamen { get; set; }
        public DateTime fechaIngreso { get; set; }

        //atributos opcionales
        public int? idPaciente { get; set; }
        public int? idMedicoGrl { get; set; }

        public List<CrearVmDetalleSolicitudExamen> solicitudExamenes { get; set; }
    }
}

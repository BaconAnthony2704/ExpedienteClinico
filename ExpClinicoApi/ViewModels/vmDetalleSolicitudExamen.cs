using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmDetalleSolicitudExamen
    {
        public int idDetalleSolicitudExamen { get; set; }
        public int? idExamen { get; set; }
        public string examen { get; set; }
        
        //public string SolicitudExamen { get; set; }

        //atributos opcionales
        //public int? idExamen { get; set; }
        //public int? idSolicitudExamen { get; set; }
    }
}

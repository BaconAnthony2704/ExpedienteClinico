using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsDetalleSolicitudExamen
    {
        public int idDetalleSolicitudExamen { get; set; }
        [ForeignKey("idExamen")]
        public clsExamen examen { get; set; }
        [ForeignKey("idSolicitudExamen")]
        public clsSolicitudExamen SolicitudExamen { get; set; }

        //atributos opcionales
        public int? idExamen { get; set; }
        public int? idSolicitudExamen { get; set; }
    }
}

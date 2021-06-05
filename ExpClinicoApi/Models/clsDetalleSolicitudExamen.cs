using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsDetalleSolicitudExamen
    {
        public int clsSolicitudExamenId { get; set; }
        public int clsExamenId { get; set; }
           
        public clsSolicitudExamen clsSolicitudExamen { get; set; }
        public clsExamen clsExamen { get; set; }

    }
}

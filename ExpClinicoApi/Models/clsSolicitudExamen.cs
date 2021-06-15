using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsSolicitudExamen
    {
        public int id { get; set; }
        public int idClsPaciente { get; set; }
        public int idClsDoctor { get; set; }
        public DateTime date { get; set; }
        public List<clsDetalleSolicitudExamen> detalleExamenes { get; set; }

    }
}

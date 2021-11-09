using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmPlanilla
    {
        public int idEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string cargo { get; set; }
        public float sueldo { get; set; }
        public float montoAnticipo { get; set; }
        public float montoDescuento { get; set; }
        public float isss { get; set; }
        public float afp { get; set; }
        public float totalDescuento { get; set; }
        public float totalPagar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmDescuento
    {
        public int idDescuento { get; set; }
        public string descripcion { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }
        public int idEmpleado { get; set; }
    }
}

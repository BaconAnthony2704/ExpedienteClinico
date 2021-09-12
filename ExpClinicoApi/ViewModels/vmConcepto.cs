using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmConcepto
    {
        public int idConcepto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int nivel { get; set; }
        public string tipo { get; set; }
        public string relacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsConcepto
    {
        public int IdConcepto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Nivel { get; set; }
        public string Tipo { get; set; }
        public string Relacion { get; set; }
        public bool IsActive { get; set; }
        public DateTime Modified { get; set; }

    }
}

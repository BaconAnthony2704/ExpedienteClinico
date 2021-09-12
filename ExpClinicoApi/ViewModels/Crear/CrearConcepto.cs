using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Crear
{
    public class CrearConcepto
    {
      
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Nivel { get; set; }
        public string Tipo { get; set; }
        public string Relacion { get; set; }
        
    }
}

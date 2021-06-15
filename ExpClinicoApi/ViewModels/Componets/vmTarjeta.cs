using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Componets
{
    public class vmTarjeta
    {
        public int idTarjeta { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set; }
        public string urlimagen { get; set; }
        public string color { get; set; }
        public bool estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsIncapacidad
    {
        public int idTipoIncapacidad { get; set; }
        public bool estado { get; set; }
        public bool tipo { get; set; }
        public string nombre { get; set; }
        public bool isRestricciones { get; set; }
        public bool isListaAlergia { get; set; }
    }
}

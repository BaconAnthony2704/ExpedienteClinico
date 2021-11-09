using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class ExistenciaViewModel
    {
        public int IDMEDICAMENTO { get; set; }

        public string NOMBRE { get; set; }

        public string TIPO { get; set; }

        public string EXISTENCIA { get; set; }
        public string DESCRIPCION { get; set; }
        public string ESTADO { get; set; }
    }
}

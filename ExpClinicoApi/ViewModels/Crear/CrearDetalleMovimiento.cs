using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Crear
{
    public class CrearDetalleMovimiento
    {
        public int idPaciente { get; set; }
        public int idConcepto { get; set; }
        public float montoIngreso { get; set; }
        public DateTime fecha { get; set; }
        public string documento { get; set; }

    }
}

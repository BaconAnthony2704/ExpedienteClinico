using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmDetalleMovimiento
    {
        public int idDetalleMovimiento { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string documento { get; set; }
        public float monto { get; set; }
        public string isr { get; set; }
        public string observacion { get; set; }
        public string paciente { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int nivel { get; set; }
        public string tipo { get; set; }
        public string relacion { get; set; }
        public string tipoNombre { get; set; }
        public string descripcionConcepto { get; set; }
    }
}

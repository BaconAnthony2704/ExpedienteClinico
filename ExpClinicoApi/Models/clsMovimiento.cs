using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsMovimiento
    {
        public int IdMovimiento { get; set; }


        [ForeignKey("IdConcepto")]
        public clsConcepto Concepto { get; set; }

        public DateTime FechaIngreso { get; set; }
        public string Documento { get; set; }
        public float Monto { get; set; }
        public string Isr { get; set; }
        public string Observacion { get; set; }
        public bool IsActive { get; set; }
        public DateTime Modified { get; set; }

        //provinsionales
        public int? IdConcepto { get; set; }
    }
}

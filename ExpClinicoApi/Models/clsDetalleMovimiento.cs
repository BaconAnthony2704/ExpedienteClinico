using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class clsDetalleMovimiento
    {
        
        public int IdDetalleMovimiento { get; set; }
        [ForeignKey("IdMovimiento")]
        public clsMovimiento Movimiento { get; set; }
        [ForeignKey("IdPaciente")]
        public clsPaciente Paciente { get; set; }
        public bool IsActive { get; set; }
        public DateTime Modified { get; set; }

        //atributos provinsionales
        public int? IdMovimiento { get; set; }
        public int? IdPaciente { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpClinicoApi.Models
{
    public class clsFechaVencimiento
    {
        [Key]
        public int idFechaVencimiento { get; set; }
        [ForeignKey("codigo")]
        
        public clsMedicamento idMedicamento { get; set; }
    }
}
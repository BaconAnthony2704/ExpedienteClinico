using ExpClinicoApi.Models.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    [Table("tblexploracionfisica")]
    public class clsExploracionFisica
    {            //idExploracionFisica
        [Key]
        public int idExploracionFisica { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        [ForeignKey("idTipoPiel")]
        public GlTipoPiel tipoPiel { get; set; }
        public string marcaNaci { get; set; }
        [ForeignKey("idColorCabello")]
        public GlColorCabello colorCabello { get; set; }
        public bool OcupaLentes { get; set; }
        public bool PresentaDisca { get; set; }
        public bool ProblemaAuditivo { get; set; }
        
        //atributos opcionales
        public int? idTipoPiel { get; set; }
        public int? idColorCabello { get; set; }
    }
}

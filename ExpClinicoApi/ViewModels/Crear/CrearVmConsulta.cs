using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Crear
{
    public class CrearVmConsulta
    {
        [Key]
        public int idConsulta { get; set; }
        public int? idPaciente { get; set; }
        public int? idHistorialMedico { get; set; }
        public int? idTipoConsulta { get; set; }
        public DateTime fechaConsulta { get; set; }

    }
}

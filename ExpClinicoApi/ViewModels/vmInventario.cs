using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmInventario
    {
        
        public int idTransaccionMedicamento { get; set; }
        //public clsMedicamento Medicamento { get; set; }

        //public clsRecetaMedicamento Receta { get; set; }

        public int idReceta { get; set; }
        public int idMedicamento { get; set; }
        public int tipo_transaccion { get; set; }   //1- entrada , 2-salidad
        public int cantidad { get; set; }

        public string paciente { get; set; }
    }
}

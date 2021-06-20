using System;

namespace ExpClinicoApi.ViewModels
{
    public class vmCita
    {
        public int idCita { get; set; }
        public string nombrePaciente { get; set; }
        public DateTime fechaIngreso { get; set; }
    }
}
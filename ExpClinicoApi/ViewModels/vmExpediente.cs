using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmExpediente
    {
        public string ExpedienteNo { get; set; }
        public string titulo { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string domicilioPaciente { get; set; }
        public string fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string NoISSS { get; set; }
        public string LugarNacimiento { get; set; }
        public string telefonoDomicilio { get; set; }
        public string telefonoOficina { get; set; }
        public string correo { get; set; }
        public string estadoCivil { get; set; }
        public string conyugue { get; set; }
        public bool nvoPaciente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public string tipoPiel { get; set; }
        public string marcaNaci { get; set; }
        public string imc { get; set; }
        public string colorCabello{ get; set; }
        public bool ocupaLentes { get; set; }
        public bool presentaDisc { get; set; }
        public bool problemaAuditivo { get; set; }
        public string medicoGrl { get; set; }
        public string telefonoMedico { get; set; }
        public string dentistaFamilia { get; set; }
        public string direccionMedico { get; set; }
        public string hospital{ get; set; }
        public string seguro { get; set; }
        public string poliza { get; set; }
        public DateTime ultimaVacuna { get; set; }
        public List<clsAlergia> alergias { get; set; }
        public List<clsIncapacidad> incapacidades { get; set; }

    }
}

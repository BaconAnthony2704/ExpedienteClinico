using ExpClinicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels.Crear
{
    public class CrearVmExpediente
    {
        public int idExpediente { get; set; }
        //"public int idInformacionPersonal { get; set; }
        //public string ExpedienteNo { get; set; }
        //public string titulo { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string domicilioPaciente { get; set; }
        public DateTime fechaNacimiento { get; set; }
        //clave de idGenero
        public int IdGenero { get; set; }
        public string UrlImagen { get; set; }
        public string NoISSS { get; set; }
        public string LugarNacimiento { get; set; }
        public string telefonoDomicilio { get; set; }
        public string telefonoOficina { get; set; }
        public string correo { get; set; }
        public string responsableA { get; set; }

        //clave idEstadoCivil
        public int IdEstadoCivil { get; set; }


        public string conyugue { get; set; }
        public bool nvoPaciente { get; set; }
        public DateTime fechaIngreso { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }

        //clave tipoPiel
        public int IdTipoPiel { get; set; }


        public string marcaNaci { get; set; }
        public double imc { get; set; }

        //clave IdColorCabello
        public int IdColorCabello { get; set; }


        public bool ocupaLentes { get; set; }
        public bool presentaDisc { get; set; }
        public bool problemaAuditivo { get; set; }
        public string medicoGrl { get; set; }
        public string telefonoMedico { get; set; }
        public string dentistaFamilia { get; set; }
        public string direccionMedico { get; set; }

        //clave idHospital
        public int IdHospital { get; set; }

        //clave idSeguro
        public int IdSeguro { get; set; }
        //public string nombreSeguro { get; set; }
        public string poliza { get; set; }
        public DateTime ultimaVacuna { get; set; }
        public List<pivoteAlergiaExp> alergias { get; set; }
        public List<pivoteIncapacidadExpediente> incapacidades { get; set; }
        //public DateTime fechaCreacion { get; set; }
        public string TipoPiel { get; set; }
        public string ColorCabello { get; set; }
    }
}

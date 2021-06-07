using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class pivoteAlergiaExp
    {
        public int idAlergiaExp { get; set; }
        public int idAlergia { get; set; }
        public int idExpediente { get; set; }
    }
}

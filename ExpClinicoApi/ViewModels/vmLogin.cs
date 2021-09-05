using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.ViewModels
{
    public class vmLogin
    {
        public int idUser { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isactive { get; set; }
        public DateTime modified { get; set; }
    }
}

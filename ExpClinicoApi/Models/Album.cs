using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistaName { get; set; }
        public int Price { get; set; }
        public string Genre { get; set; }
    }
}

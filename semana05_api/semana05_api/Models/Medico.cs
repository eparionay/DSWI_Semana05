using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana05_api.Models
{
    public class Medico
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string especialidad { get; set; }
        public string documento { get; set; }

    }
}
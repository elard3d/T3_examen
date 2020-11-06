using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models
{
    public class Rutina
    {
        public int id{ get; set; }
        public string nombreRutina { get; set; }
        public string tipoRutina { get; set; }
        public int idUsuario { get; set; }

        public Usuarios usuario{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models
{
    public class EjercicioRutina
    {
        public int idEjercicioRutina { get; set; }
        public int idRutina { get; set; }
        public int idEjercicio { get; set; }
        public int tiempoRutina { get; set; }

        public Ejercicios ejercicios { get; set; }
        public Rutina rutina { get; set; }


    }
}

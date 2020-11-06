using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T3_examen.Models.Patron_Estrategia
{
    public class Avanzada : IEstrategia
    {

        public EjercicioContext context;

        public Avanzada (EjercicioContext context)
        {
            this.context = context;

        }
        public void crearEjercicios(int idRutina)
        {
            var random = new Random(System.DateTime.Now.Millisecond);
            for (int i =0; i <= 14; i++)
            {
                var ejercicioRutina = new EjercicioRutina();
                ejercicioRutina.idEjercicio = random.Next(1, 21);
                ejercicioRutina.idRutina = idRutina;
                ejercicioRutina.tiempoRutina = 120;

                context.EjercicioRutina.Add(ejercicioRutina);
                context.SaveChanges();


            }
        }
    }
}
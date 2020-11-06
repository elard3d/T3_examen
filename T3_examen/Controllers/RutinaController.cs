using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using T3_examen.Models;
using T3_examen.Models.Patron_Estrategia;

namespace T3_examen.Controllers
{
    public class RutinaController : Controller
    {

        private EjercicioContext context;
        private readonly IConfiguration configuration;

        public RutinaController(EjercicioContext _context, IConfiguration _configuration)
        {

            this.context = _context;
            this.configuration = _configuration;

        }

        [HttpGet]
        public ActionResult CrearRutina()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CrearRutina(string nombre, string tipo)
        {
            var rutina = new Rutina();
            var claim = HttpContext.User.Claims.FirstOrDefault();

            int idUsuario = context.usuarios.Where(o => o.usuario == claim.Value).FirstOrDefault().id;
            rutina.nombreRutina = nombre;
            rutina.tipoRutina = tipo;
            rutina.idUsuario = idUsuario;
            context.Rutina.Add(rutina);
            context.SaveChanges();
            int idRutina = rutina.id;
            switch (tipo)
            {
                case "Principiante":
                    var principiante = new Principiante(context);
                    principiante.crearEjercicios(idRutina);
                    break;
                case "Intermedio":
                    var intermedio = new Intermedio(context);
                    intermedio.crearEjercicios(idRutina);
                    break;
                case "Avanzado":
                    var avanzado = new Avanzada(context);
                    avanzado.crearEjercicios(idRutina);
                    break;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Ejercicios");
        }

        public ActionResult MostrarRutina()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();

            int idUsuario = context.usuarios.Where(o => o.usuario == claim.Value).FirstOrDefault().id;
            ViewBag.Rutinas = context.Rutina.Where(o => o.idUsuario == idUsuario).ToList();

            return View();
        }

        public ActionResult DetalleRutina(int idRutina)
        {
            var ejercicios = context.EjercicioRutina.Include(o => o.ejercicios).Where(o => o.idRutina == idRutina).ToList();
            ViewBag.Ejercicios = ejercicios;
            return View();
        }


    }
}

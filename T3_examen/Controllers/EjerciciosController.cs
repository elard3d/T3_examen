using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T3_examen.Models;


namespace T3_examen.Controllers
{
    public class EjerciciosController : Controller
    {

        private EjercicioContext _context;

        public EjerciciosController(EjercicioContext context) {

            this._context = context;
                
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Ejercicios = _context.ejercicios.ToList();

            return View();
        }

        [Authorize]
        public IActionResult CrearRutina()
        {
            return View();
        }

        [Authorize]
        public IActionResult MostrarRutina()
        {

            var claim = HttpContext.User.Claims.FirstOrDefault();

            int idUsuario = _context.usuarios.Where(o => o.usuario == claim.Value).FirstOrDefault().id;
            ViewBag.Rutinas = _context.Rutina.Where(o => o.idUsuario == idUsuario).ToList();

            return View();
        }

        [Authorize]
        public ActionResult DetalleRutina(int idRutina)
        {
            var ejercicios = _context.EjercicioRutina.Include(o => o.ejercicios).Where(o => o.idRutina == idRutina).ToList();
            ViewBag.Ejercicios = ejercicios;
            return View();
        }
    }
}

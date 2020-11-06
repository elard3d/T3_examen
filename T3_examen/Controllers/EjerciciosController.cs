using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CrearRutina()
        {
            return View();
        }
    }
}

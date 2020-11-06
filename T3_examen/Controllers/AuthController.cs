using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using T3_examen.Models;

namespace T3_examen.Controllers
{
    public class AuthController : Controller
    {

        private EjercicioContext context;
        private readonly IConfiguration configuration;

        public AuthController(EjercicioContext _context, IConfiguration _configuration)
        {

            this.context = _context;
            this.configuration = _configuration;

        }

        public string LoggedUser()
        {

            var claims = HttpContext.User.Claims.FirstOrDefault();
            var user = context.usuarios.Where(o => o.usuario== claims.Value).FirstOrDefault();

            return "el usuario logueado es " + user.usuario;

        }


        public string Index(string input)
        {
            return CreateHash(input);
        }
        
        public IActionResult Login(string usuario, string pass)
        {

            var user = context.usuarios
                .Where(o => o.usuario == usuario && o.pass == CreateHash(pass))
                .FirstOrDefault();

            if (user != null)
            {

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, usuario)
                };


                var clainmsIdentity = new ClaimsIdentity(claims, "Login");
                var clainmsPrincipal = new ClaimsPrincipal(clainmsIdentity);

                HttpContext.SignInAsync(clainmsPrincipal);

                return RedirectToAction("Index", "Ejercicios");

            }

           
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }

        private string CreateHash(String input)
        {

            var sha = SHA256.Create();
            input = input + configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);

        }


       [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string usuario, string pass)
        {
            var user = new Usuarios();

            user.usuario = usuario;

            user.pass = CreateHash(pass);

            context.usuarios.Add(user);

            context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

    }
}

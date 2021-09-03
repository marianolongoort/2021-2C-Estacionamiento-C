using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            Persona persona1 = new Persona();
            persona1.Nombre = "Pedro";
            persona1.Apellido = "Picapiedra";

            Persona persona2 = new Persona() { Nombre="Pablo",Apellido="Marmol"};

   

            return View(persona2);
        }

        private void Imprimir(Persona persona)
        {
            //logica para imprimir nombre persona.Nombre
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

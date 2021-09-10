using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
{
    public class PersonasController : Controller
    {
        private EstacionamientoContext cheMiContexto;
            

        public PersonasController(EstacionamientoContext contexto)
        {
            this.cheMiContexto = contexto;
        }


        public IActionResult Index()
        {
            Persona persona1 = new Persona() { Nombre = "Pedro", Apellido = "Picapiedra" };
            Persona persona2 = new Persona() { Nombre = "Pablo", Apellido = "Marmol" };
            Persona persona3 = new Persona() { Nombre = "Vilma", Apellido = "Picapiedra" };

            List<Persona>         listaPersonas = new List<Persona>();
            IEnumerable<Persona>  ienumPersonas = new List<Persona>();
            ICollection<Persona>  icolPersonas  = new List<Persona>();
            IList<Persona>        ilistPersonas = new List<Persona>();

            icolPersonas.Add(persona1);
            icolPersonas.Add(persona2);

            listaPersonas.AddRange(icolPersonas);


            ViewBag.Supervisor = persona3;
            


            return View(listaPersonas);
        }


        public IActionResult ListarPersonas()
        {
            
            bool hayPablos = cheMiContexto.Personas.Any(per => per.Nombre == "Pablo");
            bool hayPedros = cheMiContexto.Personas.Any(per => per.Nombre == "Pedros");

            List<Persona> losPedros = cheMiContexto.Personas.Where(per => per.Nombre == "Pedro").ToList();
            List<Persona> losPablos = cheMiContexto.Personas.Where(per => per.Nombre == "Pablo").ToList();

            if (!hayPablos)
            {
                Persona persona1 = new Persona()
                {
                    Nombre = "Pablo",
                    Apellido = "Marmol",
                    Email = "pablo@marmol.com",
                    DNI = 22333444
                };
                cheMiContexto.Personas.Add(persona1);                
            }

            if (!hayPedros)
            {
                Persona persona1 = new Persona()
                {
                    Nombre = "Pedro",
                    Apellido = "Picapiedra",
                    Email = "pedro@picapiedra.com",
                    DNI = 11222555
                };
                cheMiContexto.Personas.Add(persona1);
            }



            cheMiContexto.SaveChanges();


            ViewBag.LosPedros = losPedros;
            ViewBag.LosPablos = losPablos;

          

            List<Persona> personasEnBaseDeDAtos = cheMiContexto.Personas.ToList();

            return View(personasEnBaseDeDAtos);
        }

    }
}

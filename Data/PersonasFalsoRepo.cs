using EstacionamientoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Data
{
    public static class PersonasFalsoRepo
    {
        public static List<Persona> GetPersonas()
        {
            Persona p1 = new Persona() { Nombre = "Pedro", Apellido = "Picapiedra", DNI =11111111, Email = "pedro@roca.com" };
            Persona p2 = new Persona() { Nombre = "Vilma", Apellido = "Picapiedra", DNI =22222222, Email = "vilma@roca.com" };
            Persona p3 = new Persona() { Nombre = "Pablo", Apellido = "Marmol", DNI =33333333, Email = "pablo@roca.com" };
            Persona p4 = new Persona() { Nombre = "Betty", Apellido = "Marmol", DNI =44444444, Email = "betty@roca.com" };
            
            List<Persona> personas = new List<Persona>();
            personas.Add(p1);
            personas.Add(p2);
            personas.Add(p3);
            personas.Add(p4);
            return personas;
        }
    }
}

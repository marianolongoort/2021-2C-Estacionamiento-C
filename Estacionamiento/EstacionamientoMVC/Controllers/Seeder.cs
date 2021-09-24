using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Controllers
{
    public class Seeder : Controller
    {
        private readonly EstacionamientoContext _garageContext;

        public Seeder(EstacionamientoContext garageContext)
        {
            this._garageContext = garageContext;
        }
        public IActionResult Index()
        {

            #region Personas
            if (!_garageContext.Personas.Any())
            {
                Persona persona1 = new Persona() { Nombre = "Pedro", Apellido = "Picapiedra", DNI = 11222333, Email = "pedro@dominio.com" };
                Persona persona2 = new Persona() { Nombre = "Pablo", Apellido = "Marmol", DNI = 22333444, Email = "pablo@dominio.com" };
                _garageContext.Add(persona1);
                _garageContext.Add(persona2);
            }

            #endregion


            #region Clientes
            if (!_garageContext.Clientes.Any())
            {
                Cliente clt1 = new Cliente() { Nombre = "Tony", Apellido = "Stark", DNI = 11222333, Email = "tony@dominio.com" ,CUIT= 20112223330 };
                Cliente clt2 = new Cliente() { Nombre = "Bruce", Apellido = "Banner", DNI = 22333444, Email = "bruce@dominio.com",CUIT= 20223334440 };
                _garageContext.Add(clt1);
                _garageContext.Add(clt2);
            }

            #endregion


            #region Empleados
            if (!_garageContext.Empleados.Any())
            {
                Empleado emp1 = new Empleado() { Nombre = "Pete", Apellido = "Mitchell", DNI = 11222333, Email = "maverick@dominio.com" ,CodigoEmpleado= "Emp4k89102" };
                Empleado emp2 = new Empleado() { Nombre = "Tom", Apellido = "Kazansky", DNI = 22333444, Email = "iceman@dominio.com", CodigoEmpleado = "Emp4k89103" };
                _garageContext.Add(emp1);
                _garageContext.Add(emp2);
            }

            #endregion
            _garageContext.SaveChanges();

            #region Direcciones
            if (!_garageContext.Direcciones.Any())
            {
                var clientes = _garageContext.Clientes.ToList();

                if (clientes.Count > 1)
                {
                    Cliente clt1 = clientes[0];
                    Cliente clt2 = clientes[1];

                    Direccion dir1 = new Direccion() { Calle = "Charcas", Numero = 2233, CodigoPostal = "C1424A", Piso = 9, Departamento = "A", Id = clt1.Id };
                    Direccion dir2 = new Direccion() { Calle = "Cordoba", Numero = 5566, CodigoPostal = "C1222A", Piso = 4, Departamento = "B", Id = clt2.Id };
                    _garageContext.Add(dir1);
                    _garageContext.Add(dir2);
                }
            }
            #endregion


            #region Telefonos
            if (!_garageContext.Telefonos.Any())
            {
                var clt1 = _garageContext.Clientes.FirstOrDefault();
                var emp1 = _garageContext.Empleados.FirstOrDefault();

                if (clt1 != null)
                {
                    Telefono tel1 = new Telefono() { CodArea = 011, Numero = 22223333, Tipo = TipoTelefono.Personal, Principal = true, PersonaId = clt1.Id };
                    Telefono tel2 = new Telefono() { CodArea = 011, Numero = 33334444, Tipo = TipoTelefono.Laboral, Principal = false, PersonaId = clt1.Id };
                    Telefono tel3 = new Telefono() { CodArea = 011, Numero = 1544445555, Tipo = TipoTelefono.Celular, Principal = false, PersonaId = clt1.Id };



                    _garageContext.Add(tel1);
                    _garageContext.Add(tel2);
                    _garageContext.Add(tel3);
                }

                if (emp1 != null)
                {
                    Telefono tel4 = new Telefono() { CodArea = 011, Numero = 55556666, Tipo = TipoTelefono.Personal, Principal = true, PersonaId = emp1.Id };
                    _garageContext.Add(tel4);
                }
            }
            #endregion
            _garageContext.SaveChanges();

            ViewBag.Personas = _garageContext.Personas.ToList();
            ViewBag.Empleados = _garageContext.Empleados.ToList();
            ViewBag.Clientes = _garageContext.Clientes.ToList();
            ViewBag.Direcciones = _garageContext.Direcciones.ToList();
            ViewBag.Telefonos = _garageContext.Telefonos.ToList();

            return RedirectToAction("Index","Personas");
        }
    }
}

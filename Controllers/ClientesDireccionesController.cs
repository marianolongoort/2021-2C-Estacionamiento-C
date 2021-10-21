using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamientoMVC.Data;
using EstacionamientoMVC.ViewModels;
using EstacionamientoMVC.Models;

namespace EstacionamientoMVC.Controllers
{
    public class ClientesDireccionesController : Controller
    {
        private readonly GarageContext _context;

        public ClientesDireccionesController(GarageContext context)
        {
            _context = context;
        }

        

        public IActionResult Create()
        {
            ClienteDireccion cd = new ClienteDireccion() { 
                Nombre = "Pedrito",
                Apellido = "Picapiedra",
                DNI = 11222333,
                CUIT = 20112223330,
                Calle = "roca buena",
                Numero = 6677,
                Piso = 10,
                Departamento = "A",
                CodigoPostal = "1414",
                Email = "pedro@roca.com"
            };

            return View(cd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellido,DNI,Email,CUIT,Calle,Numero,Piso,Departamento,CodigoPostal")] ClienteDireccion vm)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = vm.Nombre,
                    Apellido = vm.Apellido,
                    DNI = vm.DNI,
                    Email = vm.Email,
                    CUIT = vm.CUIT
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                Direccion direccion = new Direccion()

                { 
                    Calle = vm.Calle,
                    Numero = vm.Numero,
                    Piso = vm.Piso,
                    Departamento = vm.Departamento,
                    CodigoPostal = vm.CodigoPostal,
                    Id = cliente.Id
                };
                _context.Direcciones.Add(direccion);
                _context.SaveChanges();


                return RedirectToAction("Index","Clientes");
            }
            return View(vm);

            
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return Content("El id no puede ser null");
            }
            Cliente clienteEnDb = _context.Clientes.Include(c => c.Direccion).Include(c => c.Telefonos).FirstOrDefault(c => c.Id == id);
            //Cliente clienteEnDb = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (clienteEnDb == null)
            {
                return Content("El cliente no está en la base de datos");
            }

            ClienteDireccion cd = new ClienteDireccion()
            { 
                Apellido = clienteEnDb.Apellido,
                Calle = clienteEnDb.Direccion.Calle,
                Numero = clienteEnDb.Direccion.Numero,
                Piso = clienteEnDb.Direccion.Piso,
                Departamento = clienteEnDb.Direccion.Departamento                
            };

            return View(cd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,DNI,Email,IdDireccion,Calle,Numero,Piso,Departamento,CodigoPostal")] ClienteDireccion clienteDireccion)
        {
            if (id != clienteDireccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteDireccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ClienteDireccionExists(clienteDireccion.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDireccion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            return RedirectToAction(nameof(Index));
        }


    }
}

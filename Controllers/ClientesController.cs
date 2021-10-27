using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace EstacionamientoMVC.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly GarageContext _garageContext;

        public ClientesController(GarageContext context)
        {
            _garageContext = context;
        }

      
        public async Task<IActionResult> Index()
        {
            return View(await _garageContext.Clientes.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _garageContext.Clientes                                            
                                            .Include(clt => clt.Telefonos)
                                            .Include(clt => clt.Direccion)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            
            
            
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [Authorize(Roles = "Empleado,Administrador")]
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Empleado,Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(bool crearDireccion,[Bind("CUIT,Id,Nombre,Apellido,DNI,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _garageContext.Add(cliente);
                await _garageContext.SaveChangesAsync();
                if (crearDireccion) {
                    return RedirectToAction("Create", "Direcciones", new { id = cliente.Id });
                }

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != Int32.Parse(User.Claims.First().Value))
            {
                return RedirectToAction("AccesoDenegado", "Account");
            }

            var cliente = await _garageContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CUIT,Id,Nombre,Apellido,DNI,Email")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (id != Int32.Parse(User.Claims.First().Value))
            {
                return RedirectToAction("AccesoDenegado", "Account");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Dado que solo se contemplan algunos datos, se trae el objeto completo y solo se actualizan algunos campos
                    Cliente cltEnDb = _garageContext.Clientes.Find(cliente.Id);
                    cltEnDb.CUIT = cliente.CUIT;
                    cltEnDb.Nombre = cliente.Nombre;
                    cltEnDb.Apellido = cliente.Apellido;
                    cltEnDb.DNI = cliente.DNI;
                    
                    _garageContext.Update(cltEnDb);
                    await _garageContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        [Authorize(Roles = "Empleado,Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _garageContext.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [Authorize(Roles = "Empleado,Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _garageContext.Clientes.FindAsync(id);
            _garageContext.Clientes.Remove(cliente);
            await _garageContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _garageContext.Clientes.Any(e => e.Id == id);
        }
    }
}

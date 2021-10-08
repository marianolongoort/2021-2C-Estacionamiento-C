using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;

namespace EstacionamientoMVC.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly EstacionamientoContext _context;

        public DireccionesController(EstacionamientoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var estacionamientoContext = _context.Direcciones.Include(d => d.Cliente);
            return View(await estacionamientoContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        public IActionResult Create(int? idPersona)
        {
            //si no recibo el id, que hago?
            if(idPersona == null)
            {
                ViewData["Id"] = new SelectList(_context.Clientes.Include(clt => clt.Direccion).Where(clt => clt.Direccion == null )   , "Id", "NombreCompleto");
            }
            else
            {
                ViewBag.IdPersona = idPersona;
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Apellido", direccion.Id);
            return View(direccion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Apellido", direccion.Id);
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            ViewData["Id"] = new SelectList(_context.Clientes, "Id", "Apellido", direccion.Id);
            return View(direccion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _context.Direcciones.FindAsync(id);
            _context.Direcciones.Remove(direccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _context.Direcciones.Any(e => e.Id == id);
        }
    }
}

using EstacionamientoMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamientoMVC.ViewModels;

namespace EstacionamientoMVC.Data
{
    public class EstacionamientoContext : DbContext
    {

        public EstacionamientoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

    }
}

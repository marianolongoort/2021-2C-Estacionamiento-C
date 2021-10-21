using EstacionamientoMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamientoMVC.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EstacionamientoMVC.Data
{
    public class GarageContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public GarageContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Relaciones Muchos a Muchos, por medio de Fluent API
            modelBuilder.Entity<ClienteVehiculo>().HasKey(cv => new { cv.ClienteId, cv.VehiculoId });

            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Cliente)
                .WithMany(c => c.VehiculosAutorizados)
                .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                .HasOne(cv => cv.Vehiculo)
                .WithMany(v => v.PersonasAutorizadas)
                .HasForeignKey(cv => cv.VehiculoId);


            //Definición de nombre de tablas
            
            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            //Comporatmientos especificos para el manejo de entidades.
        }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }


        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Telefono>  Telefonos { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<EstacionamientoMVC.Models.ClienteVehiculo> ClienteVehiculo { get; set; }

        public DbSet<Pago> Pagos { get; set; }

    
        
    }
}

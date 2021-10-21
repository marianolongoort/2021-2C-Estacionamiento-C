using EstacionamientoMVC.Data;
using EstacionamientoMVC.Models;
using EstacionamientoMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC
{
    public class Startup
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region Tipo de DB Provider a usar
            try
            {
                _dbInMemory = Configuration.GetValue<bool>("DbInMem");
            }
            catch
            {
                //Dejamos el tratamiento que le queremos dar. En este caso asumimos que si falla la lectura del appsettings.json tomamos en memoria.
                _dbInMemory = true;
            }
            #endregion

        }

        public IConfiguration Configuration { get; }

        private bool _dbInMemory = false;

        public void ConfigureServices(IServiceCollection services)
        {
            #region Tipo de DB Provider a usar
            if (_dbInMemory)
            {
                services.AddDbContext<GarageContext>(options => options.UseInMemoryDatabase("EstacionamientoDB"));
            }
            else
            {
                services.AddDbContext<GarageContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GarageCS"))//Obtenemos el Connection String a partir de la Clave GarageCS
                );
            }
            #endregion

            services.AddScoped<IMensajero, PalomaMensajera>();


            #region Identity
            services.AddIdentity<Persona, Rol>().AddEntityFrameworkStores<GarageContext>();

            services.Configure<IdentityOptions>(
                opciones =>
                {
                    opciones.Password.RequiredLength = 2;                    
                }
                );

            #endregion


            //Para definir, donde lograr hacer un login de la cuenta ante un requerimiento de authenticación.
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opciones =>
                {
                    opciones.LoginPath = "/Account/IniciarSesion";
                    opciones.AccessDeniedPath = "/Account/AccesoDenegado";
                });


            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,GarageContext garageContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Contemplar que las migraciones de EF estén siempre cargadas, pero cuando son aplicables.
            if (!_dbInMemory)
            {
                garageContext.Database.Migrate();
            }

            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

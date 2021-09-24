using EstacionamientoMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Vehiculo
    {
        [Display(Name = Alias.VehiculoId)]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Patente { get; set; }
        
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Marca { get; set; }
                
        [Required(ErrorMessage = ErrMsgs.Requerido)]        
        public string Color { get; set; } 

        
        [Range(Restrictions.FloorVehiculoAnio, Restrictions.CeilVehiculoAnio, ErrorMessage = ErrMsgs.RangoMinMax)]
        [Display(Name = Alias.Anio)]
        public int AnioFabricacion { get; set; } = DateTime.Now.Year;

        public List<ClienteVehiculo> ClientesAutorizados { get; set; }
    }
}

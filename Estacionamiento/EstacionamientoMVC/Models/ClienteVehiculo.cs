using EstacionamientoMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.Models
{
    public class ClienteVehiculo
    {
        [Key]
        [Display(Name = Alias.ClienteId)]
        public int ClienteId { get; set; }
        [Key]
        [Display(Name = Alias.VehiculoId)]
        public int VehiculoId { get; set; }
        
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public bool ResponsablePrincipal { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.Models
{
    public class ClienteVehiculo
    {
        [Key]
        public int ClienteId { get; set; }
        [Key]
        public int VehiculoId { get; set; }
        public Cliente  Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public bool ResponsablePrincipal { get; set; }
    }
}
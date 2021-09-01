namespace EstacionamientoMVC.Models
{
    public class PersonaVehiculo
    {
        public int PersonaId { get; set; }
        public int VehiculoId { get; set; }
        public Persona Persona { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public bool ResponsablePrincipal { get; set; }
    }
}
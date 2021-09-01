using EstacionamientoMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Display(Name = Alias.PersonaId)]
        public int PersonaId { get; set; } 

        public Persona Persona { get; set; } 

    }
}
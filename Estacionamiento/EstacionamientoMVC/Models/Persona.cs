using EstacionamientoMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage =ErrMsgs.Requerido)]
        [StringLength(Restrictions.CeilL3,MinimumLength =Restrictions.FloorL1,ErrorMessage =ErrMsgs.StrMaxMin)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [MaxLength(Restrictions.CeilL3,ErrorMessage = ErrMsgs.StrMax)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Range(Restrictions.FloorDNI,Restrictions.CeilDNI,ErrorMessage = ErrMsgs.RangoMinMax)]
        [Display(Name = Alias.DNI)]
        public int DNI { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.EmailAddress,ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }

        public List<PersonaVehiculo> VehiculosAutorizados { get; set; }

    }
}

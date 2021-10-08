using EstacionamientoMVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(Restrictions.FloorDNI, Restrictions.CeilDNI, ErrorMessage = ErrMsgs.RangoMinMax)]
        [Display(Name = Alias.DNI)]
        public int DNI { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.EmailAddress,ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        [Remote(action: "Emaildisponible", controller:"personas")]
        public string Email { get; set; }


        [Display(Name = Alias.NombreCompleto)]
        public string NombreCompleto { get             
            {
                if (Apellido == null) return Nombre;
                return $"{Apellido.ToUpper()}, {Nombre}";
            }
        }

        public List<Telefono> Telefonos { get; set; }
    }
}

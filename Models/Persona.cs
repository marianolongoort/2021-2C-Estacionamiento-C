using EstacionamientoMVC.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Persona : IdentityUser<int>
    {        
        //public int Id { get; set; }

        
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
        [EmailAddress( ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        public override string Email {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public List<Telefono> Telefonos { get; set; }


        [Display(Name = Alias.NombreCompleto)]
        public string NombreCompleto {             
            get {
                if (string.IsNullOrEmpty(Apellido)) return Nombre;                
                return $"{Apellido.ToUpper()}, {Nombre}";
            }
        }


        public void Saludar(string mensaje) { }

    }
}

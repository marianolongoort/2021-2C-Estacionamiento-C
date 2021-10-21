using EstacionamientoMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.ViewModels
{
    public class ClienteDireccion
    {
        public int Id { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.CeilL3, MinimumLength = Restrictions.FloorL1, ErrorMessage = ErrMsgs.StrMaxMin)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [MaxLength(Restrictions.CeilL3, ErrorMessage = ErrMsgs.StrMax)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [Range(Restrictions.FloorDNI, Restrictions.CeilDNI, ErrorMessage = ErrMsgs.RangoMinMax)]
        [Display(Name = Alias.DNI)]
        public int DNI { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.EmailAddress, ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        public string Email { get; set; }

        [Range(Restrictions.FloorCUIL, Restrictions.CeilCUIL, ErrorMessage = ErrMsgs.RangoMinMax)]
        public long CUIT { get; set; }

        [Display(Name = Alias.NombreCompleto)]
        public string NombreCompleto
        {
            get
            {
                if (string.IsNullOrEmpty(Apellido)) return Nombre;
                return $"{Apellido.ToUpper()}, {Nombre}";
            }
        }


        public int IdDireccion { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Calle { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Numero { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Piso { get; set; } = 0;


        public string Departamento { get; set; } = "N/A";
        public string CodigoPostal { get; set; }


    }
}

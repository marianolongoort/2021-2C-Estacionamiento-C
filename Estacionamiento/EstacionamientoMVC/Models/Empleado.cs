using EstacionamientoMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Empleado : Persona
    {
        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [StringLength(Restrictions.FloorL4, MinimumLength = Restrictions.CeilL1, ErrorMessage = ErrMsgs.FixedSize)]
        public string CodigoEmpleado { get; set; }

        public Telefono Telefono { get; set; }
    }
}

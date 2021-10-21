using EstacionamientoMVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Cliente : Persona
    {
        [Range(Restrictions.FloorCUIL, Restrictions.CeilCUIL, ErrorMessage = ErrMsgs.RangoMinMax)]
        public long CUIT { get; set; }

        public Direccion Direccion { get; set; }

        public List<ClienteVehiculo> VehiculosAutorizados { get; set; }
    }
}

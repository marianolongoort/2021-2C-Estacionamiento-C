using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.Models
{
    public class Pago
    {
        public int Id { get; set; }

        public decimal Monto { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [StringLength(40)]
        public string OtraProp { get; set; }

    }
}

using EstacionamientoMVC.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.Models
{
    public class Direccion
    {
        [Display(Name = Alias.ClienteId)]
        [Key, ForeignKey("Cliente")]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public string Calle { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Numero { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        public int Piso { get; set; } = 0;


        public string Departamento { get; set; } = "N/A";
        public string CodigoPostal { get; set; }

        //[Required(ErrorMessage = ErrMsgs.Requerido)]
        //public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

    }
}
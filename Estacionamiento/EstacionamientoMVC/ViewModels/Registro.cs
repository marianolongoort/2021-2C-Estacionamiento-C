using EstacionamientoMVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.ViewModels
{
    public class Registro
    {

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.EmailAddress, ErrorMessage = ErrMsgs.NoValido)]
        [Display(Name = Alias.Email)]
        [Remote(action: "Emaildisponible", controller: "personas")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password, ErrorMessage = ErrMsgs.NoValido)]
        public string Password { get; set; }


        [Required(ErrorMessage = ErrMsgs.Requerido)]
        [DataType(DataType.Password, ErrorMessage = ErrMsgs.NoValido)]
        [Compare("Password",ErrorMessage = ErrMsgs.PassMissmatch)]
        public string ConfirmPassword { get; set; }

    }
}

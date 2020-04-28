using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTriqui.Models
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "El formato del correo es incorrecto")]
        
        public string correo { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Contraseña invalida, el número de caracteres es minimo de 4")]
        public string password { get; set; }
    }
}

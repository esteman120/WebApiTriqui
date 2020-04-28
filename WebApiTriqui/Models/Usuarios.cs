using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTriqui.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }       

        [Required]
        public string NumeroIdentificacion { get; set; }

        [MinLength(4, ErrorMessage = "Contraseña invalida, el número de caracteres es minimo de 4")]
        public string Contrasena { get; set; }
        
        [Required]
        public string Correo { get; set; }

        
        public string TipoIdentificacionId { get; set; }

        public TiposIdentificacion TipoIdentificacion { get; set; }
    }
}

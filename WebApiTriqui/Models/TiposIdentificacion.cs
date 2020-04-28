using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTriqui.Models
{
    public class TiposIdentificacion
    {
        [Key]
        public string Tipo { get; set; }

        public IEnumerable<Usuarios> usuarios { get; set; }
    }
}

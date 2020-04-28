using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTriqui.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTriqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificacionController : ControllerBase
    {
        private readonly JuegoTriquiContext context;

        public IdentificacionController(JuegoTriquiContext _Contex)
        {
            context = _Contex;
        }

        [HttpGet]
        public object Index()
        {
            try
            {
                var respuesta =  context.TipoIdentificacion.ToList();

                if (respuesta is null)
                {
                    return BadRequest(new
                    {
                        status = 404,
                        message = "Error al cargar los tipos de identificación"
                    });
                }

                return Ok(new
                {
                    status = 200,
                    data = respuesta
                });
            }
            catch (Exception exp)
            {
                return BadRequest(new
                {
                    status = 500,
                    message = "Internal Server error",
                    error = exp.Message
                });
            }
             
            
        }
    }
}

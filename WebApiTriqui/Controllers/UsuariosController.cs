using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApiTriqui.Data;
using WebApiTriqui.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTriqui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly JuegoTriquiContext context;
        private readonly ILogger logger;

        public UsuariosController(JuegoTriquiContext _Contex, ILogger<UsuariosController> _logger)
        {
            context = _Contex;
            logger = _logger;
        }

        /// <summary>
        /// Hace el login del un usuario
        /// </summary>        
        /// <param name="objLogin"></param>
        /// <response code="400">Falta alguno de los datos, correo o password</response>
        /// <response code="404">no se encontro el usuario en la base de datos</response>
        /// <response code="200">Permite el logueo por parte del usuario y devuelve la data del usuario</response>
        /// <response code="500">Error de servidor</response>
        /// <returns></returns>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login([FromBody]LoginRequest objLogin)
        {
            logger.LogInformation("iniciando loguin al usuario "+ objLogin.correo);
            try
            {
                var respuesta = context.Usuarios
                    .Where(x => x.Correo.Equals(objLogin.correo.Trim()) && x.Contrasena.Equals(objLogin.password.Trim()))
                    .FirstOrDefault();

                if (respuesta is null)
                {
                    logger.LogWarning("Error al iniciar sesion, revise y vuelva a intentarlo");
                    return BadRequest(new
                    {
                        status = 404,
                        message = "Error al iniciar sesion, revise y vuelva a intentarlo"
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
                logger.LogError("Error: " + exp.Message);
                return BadRequest(new
                {
                    status = 500,
                    message = "Internal Server error"
                });
            }

        }

        /// <summary>
        /// Crea un usuario
        /// </summary>        
        /// <param name="ObjUsuarios"></param>
        /// <response code="400">Falta alguno de los datos para la creacion del usuario</response>
        /// <response code="200">Permite la creacion de un usuario</response>
        /// <response code="500">Error de servidor</response>
        /// <returns></returns>
        [HttpPost("CrearUsuario")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CrearUsuario([FromBody]Usuarios ObjUsuarios)
        {
            try
            {
                var respuesta = context.Usuarios.Add(ObjUsuarios);
                int filas = context.SaveChanges();
                    

                if (filas == 0)
                {
                    logger.LogWarning("No se pudo crear el usuario, revise los datos");
                    return BadRequest(new
                    {
                        status = 400,
                        message = "No se pudo crear el usuario, revise los datos"
                    });
                }

                return Ok(new
                {
                    status = 200,
                    data = "Usuario creado con éxito"
                });
            }
            catch (Exception exp)
            {
                logger.LogError("Error: " + exp.Message);
                return BadRequest(new
                {
                    status = 500,
                    message = "Internal Server error"
                });
            }
        }


        /// <summary>
        /// Hace el login del un usuario
        /// </summary>        
        /// <param name="ObjUsuarios"></param>
        /// <response code="400">Falta alguno de los datos</response>
        /// <response code="404">no se encontro el usuario en la base de datos</response>
        /// <response code="200">Permite la actualizacion del registro</response>
        /// <response code="500">Error de servidor</response>
        /// <returns></returns>
        [HttpPost("ActualizarUsuario")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ActualizarUsuario([FromBody]Usuarios ObjUsuarios)
        {
            try
            {
                var usuario = context.Usuarios.Where(x => x.Id == ObjUsuarios.Id).FirstOrDefault();

                if (usuario is null)
                {
                    logger.LogWarning("El usuario a actualizar no existe");
                    return BadRequest(new
                    {
                        status = 404,
                        message = "El usuario a actualizar no existe"
                    });
                }

                usuario.Nombre = ObjUsuarios.Nombre;
                usuario.Apellido = ObjUsuarios.Apellido;
                usuario.TipoIdentificacionId = ObjUsuarios.TipoIdentificacionId;
                usuario.NumeroIdentificacion = ObjUsuarios.NumeroIdentificacion;
                usuario.Contrasena = ObjUsuarios.Contrasena;
                
                int filas = context.SaveChanges();

                if (filas == 0)
                {
                    logger.LogWarning("No se pudo actualizar el usuario, revise los datos");
                    return BadRequest(new
                    {
                        status = 400,
                        message = "No se pudo actualizar el usuario, revise los datos"
                    });
                }

                return Ok(new
                {
                    status = 200,
                    data = "Usuario actualizado con éxito"
                });
            }
            catch (Exception exp)
            {
                logger.LogError("Error: " + exp.Message);
                return BadRequest(new
                {
                    status = 500,
                    message = "Internal Server error"                    
                });
            }
        }


        /// <summary>
        /// Hace el login del un usuario
        /// </summary>        
        /// <param name="ObjUsuarios"></param>
        /// <response code="400">Falta alguno de los datos</response>
        /// <response code="404">no se encontro el usuario en la base de datos</response>
        /// <response code="200">Permite la eliminación del registro</response>
        /// <response code="500">Error de servidor</response>
        /// <returns></returns>
        [HttpPost("BorrarUsuario")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult BorrarUsuario([FromBody] Usuarios ObjUsuarios)
        {
            try
            {

                var usuario = context.Usuarios.Where(x => x.Id == ObjUsuarios.Id).FirstOrDefault();

                if (usuario is null)
                {
                    logger.LogWarning("El usuario a borrar no existe");
                    return BadRequest(new
                    {
                        status = 404,
                        message = "El usuario a borrar no existe"
                    });
                }

                context.Usuarios.Remove(usuario);
                int filas = context.SaveChanges();

                if (filas == 0)
                {
                    logger.LogWarning("No se pudo eliminar el usuario, revise los datos");
                    return BadRequest(new
                    {
                        status = 400,
                        message = "No se pudo eliminar el usuario, revise los datos"
                    });
                }

                return Ok(new
                {
                    status = 200,
                    data = "Usuario eliminado con éxito"
                });
            }
            catch (Exception exp)
            {
                logger.LogError("Error: " + exp.Message);
                return BadRequest(new
                {
                    status = 500,
                    message = "Internal Server error"
                });
            }
        }

    }
}

using ExamenFinalIncomel.Data;
using ExamenFinalIncomel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace ExamenFinalIncomel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioDBContext _usuarioDBContext;
        public LoginController(UsuarioDBContext usuarioDBContext)
        {
            _usuarioDBContext = usuarioDBContext;
        }
        [HttpGet("usuarios")]
        public IActionResult GetUsuarios() 
        {
            var details = _usuarioDBContext.Usuarios.AsQueryable();
            return Ok(details);
        }
        [HttpPost("signup")]

        public IActionResult Signup([FromBody] UsuarioModel usuarioObj)
        {
            if(usuarioObj == null)
            {
                return BadRequest();
            }
            else
            {
                _usuarioDBContext.Usuarios.Add(usuarioObj);
                _usuarioDBContext.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Usuario agregado con éxito"
                }
                    ); 
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioModel usuarioObj) 
        {
            if(usuarioObj == null)
            {
                return BadRequest();
            } 
            else
            {
                var user = _usuarioDBContext.Usuarios.Where(a =>
                a.nombre == usuarioObj.nombre
                && a.contrasenia == usuarioObj.contrasenia).FirstOrDefault();
                if(user != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Logeado exitosamente",
                        UserData = usuarioObj.nombre
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Usuario no encontrado"
                    });
                }
            } 
        }
    }
}

using ExamenFinalIncomel.Data;
using ExamenFinalIncomel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace ExamenFinalIncomel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly UsuarioDBContext _dbContext;
        public EmpleadosController(UsuarioDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("add_empleado")]

        public IActionResult AddEmpleado([FromBody] EmpleadosModel empleadoObj)
        {
            if(empleadoObj == null) 
            {
                return BadRequest(); 
            }
            else
            {
                _dbContext.Empleados.Add(empleadoObj);
               _dbContext.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Empleado agregado exitosamente"
                }
                    );
            }
        }

        [HttpPut("update_empleado")]

        public IActionResult UpdateEmpleado([FromBody]EmpleadosModel empleadoObj)
        {
            if(empleadoObj  == null) 
            {
                return BadRequest();
            }
            var empleado = _dbContext.Empleados.AsNoTracking().FirstOrDefault(
                x => x.id == empleadoObj.id);

            if(empleado == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Empleado no encontrado"
                });
                
            }
            else
            {
                _dbContext.Entry(empleadoObj).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return Ok(new
                    {
                    StatusCode = 200,
                    Message = "Empleado actualizado exitosamente"
                });
            }
        }

        [HttpDelete("delete_empleado/{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            var user = _dbContext.Empleados.Find(id);
            if (user == null)
            {
                return NotFound(new
                {
                    Status = 404,
                    Message = "usuario no encontrado"
                });
            }
            else
            {
                _dbContext.Remove(user);    
                _dbContext.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Empleado eliminado correctamente"
                });
            }
        }

        [HttpGet("get_all_empleados")]

        public IActionResult GetAllEmpleados()
        {
            var empleados = _dbContext.Empleados.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmpleadosDetail = empleados
            });
        }

        [HttpGet("get_empleadoById/{id}")]
        public IActionResult GetEmpleados(int id)
        {
            var empleado = _dbContext.Empleados.Find(id);
            if(empleado == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Usuario no encontrado"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    EmpleadosDetail = empleado
                });
            }
        }
    }
}

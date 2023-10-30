using Business.Cliente.Cliente;
using Data.Cliente;
using Entity.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Cliente 
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("GetClientes")]
         
        public ActionResult GetClientes()
        {
            var data = ClienteBusiness.GetClientes();
            return Ok(data);
        }
        [HttpPost("InsertClientes")]
         
        public ActionResult InsertClientes(ClienteModel cliente)
        {
            int rowsAffected = ClienteBusiness.InsertClientes(cliente);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Cliente insertado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al insertar el Cliente" });
            }
        }
        [HttpPost("UpdateCliente")]
         
        public ActionResult UpdateCliente(ClienteModel cliente)
        {
            int rowsAffected = ClienteBusiness.UpdateCliente(cliente);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Cliente actualizado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al actualizar el Cliente" });
            }
        }

    }
}

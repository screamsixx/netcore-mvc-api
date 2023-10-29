using Business.Tienda;
using Data.Tienda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.TiendaController
{
    [Route("api/v1/[controller]")]
     
    [ApiController]
    public class TiendaController : ControllerBase
    {
        [HttpGet("GetTiendas")]
         
        public ActionResult GetTiendas()
        {
            var data = TiendaBusiness.GetTiendas();
            return Ok(data);
        }
        [HttpPost("InsertTiendas")]
         
        public ActionResult InsertTiendas(TiendaModel Tienda)
        {
            int rowsAffected = TiendaBusiness.InsertTienda(Tienda);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Tienda insertada correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al insertar el Tienda" });
            }
        }
        [HttpPost("UpdateTienda")]
         
        public ActionResult UpdateTienda(TiendaModel Tienda)
        {
            int rowsAffected = TiendaBusiness.UpdateTienda(Tienda);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Tienda actualizada correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al actualizar la Tienda" });
            }
        }

    }
}

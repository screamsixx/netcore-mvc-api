using Business.Articulo;
using Business.Carrito;
using Data.Articulo;
using Data.Carrito;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CarritoController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarritoController: ControllerBase
    {

        [HttpPost("InsertCarrito")]
         
        public IActionResult InsertCarrito([FromBody] CarritoModel carrito)
        {
            int rowsAffected = CarritoBusiness.InsertCarrito(carrito);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Carrito insertado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al insertar en carrito" });
            }
        }

        [HttpGet("GetCarritoByClienteID")]
         
        public IActionResult GetCarritoByClienteID(int id)
        {
            var carritos = CarritoBusiness.GetCarritoByClienteID(id);
            if (carritos != null && carritos.Count > 0)
            {
                return Ok(carritos);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("SumarCantidadCarrito")]
         
        public IActionResult SumarCantidadCarrito([FromBody] Detallecarrito detallecarrito)
        {
            int rowsAffected = CarritoBusiness.SumarCantidadCarrito(detallecarrito);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Cantidad sumada correctamente en el carrito" });
            }
            else
            {
                return BadRequest(new { message = "Error al sumar la cantidad en el carrito" });
            }
        }

        [HttpPost("RestarCantidadCarrito")]
         
        public IActionResult RestarCantidadCarrito([FromBody] Detallecarrito detallecarrito)
        {
            int rowsAffected = CarritoBusiness.RestarCantidadCarrito(detallecarrito);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Cantidad restada correctamente en el carrito" });
            }
            else
            {
                return BadRequest(new { message = "Error al restar la cantidad en el carrito" });
            }
        }
    }
}

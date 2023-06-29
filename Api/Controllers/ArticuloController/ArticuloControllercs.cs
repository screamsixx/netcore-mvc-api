using Business.Articulo;
using Data.Articulo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ArticuloController
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet("GetArticulos")]
        public ActionResult GetArticulos()
        {
            var data = ArticuloBusiness.GetArticulos();
            return Ok(data);
        }

        [HttpPost("InsertArticulos")]
        public IActionResult InsertArticulos([FromBody] ArticuloModel articulo)
        {
            int rowsAffected = ArticuloBusiness.InsertArticulo(articulo);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Articulo insertado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al insertar el Articulo" });
            }
        }


        [HttpPost("UpdateArticulo")]
        public ActionResult UpdateArticulo([FromBody] ArticuloModel articulo)
        {
            int rowsAffected = ArticuloBusiness.UpdateArticulo(articulo);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Articulo actualizado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al actualizar el Articulo" });
            }
        }

        [HttpPost("DeleteArticuloByID")]
        public ActionResult DeleteArticuloByID([FromBody] ArticuloModel articulo)
        {
            int rowsAffected = ArticuloBusiness.DeleteArticuloByID(articulo);
            if (rowsAffected > 0)
            {
                return Ok(new { message = "Articulo eliminado correctamente" });
            }
            else
            {
                return BadRequest(new { message = "Error al eliminar el Articulo" });
            }
        }
        [HttpGet("GetProductosById")]
        public ActionResult GetProductosById(int articuloID)
        {
            var data = ArticuloBusiness.GetProductosById(articuloID);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }


    }
}

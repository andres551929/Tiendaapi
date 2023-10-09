using Microsoft.AspNetCore.Mvc;
using Tiendaapi.Models;
using Tiendaapi.Data;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MProductos>>> Get()
        {
            var funcion = new DProductos();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            await funcion.InsertarProductos(parametros);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            //await funcion.EditarProductos(parametros);
            parametros.id = id;
            await funcion.EditarProductos(parametros);
            return NoContent(); 
        }

        [HttpDelete("{iddelete}")]
        public async Task<IActionResult> Delete(int iddelete)
        {
            var funcion = new DProductos();
            //await funcion.EditarProductos(parametros);
            //parametros.id = id;
            await funcion.EliminarProductos(iddelete);
            return NoContent();
        }

    }
}

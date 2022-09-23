using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producto.BD;
using Producto.BD.Data.Entidades;

namespace Modelado2022Registro.Server.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly BDContext context;

        public ProductoController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto.BD.Data.Entidades.Producto>> Get(int id)
        {
            var venta = await context.Producto
                                         .Where(e => e.Id == id)
                                         .Include(m => m.Renglones)
                                         .FirstOrDefaultAsync();

            if (venta == null)
            {
                return NotFound($"No existe el producto de id: {id}");
            }
            return venta;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto.BD.Data.Entidades.Producto venta)
        {
            try
            {
                context.Producto.Add(venta);
                await context.SaveChangesAsync();
                return venta.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Producto.BD.Data.Entidades.Producto produ)
        {
            if (id != produ.Id)
            {
                return BadRequest("No se encuentra la venta");
            }

            var ventas = context.Producto.Where(e => e.Id == id).FirstOrDefault();

            if (ventas == null)
            {
                return NotFound("No existe la venta a modificar");
            }

            ventas.NombreProducto = produ.NombreProducto;
            ventas.PrecioProducto = produ.PrecioProducto;
            ventas.CodigoProducto = produ.CodigoProducto;
            ventas.Stock = produ.Stock;


            try
            {
                context.Producto.Update(ventas);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var produ = context.Producto.Where(x => x.Id == id).FirstOrDefault();
  

            if (produ == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Producto.Remove(produ);



                context.SaveChanges();
                return Ok($"El registro de {produ.Id} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }
    }
}

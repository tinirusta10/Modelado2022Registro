using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producto.BD;
using Producto.BD.Data.Entidades;

namespace Modelado2022Registro.Server.Controllers
{
    [Route("api/Factura")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly BDContext context;

        public VentaController(BDContext context)
        {
            this.context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Factura>> Get(int id)
        {
            var venta = await context.Factura
                                         .Where(e => e.Id == id)
                                         .Include(m => m.cliente)
                                         .Include(m => m.Renglones)
                                         .FirstOrDefaultAsync();

            if (venta == null)
            {
                return NotFound($"No existe venta de id: {id}");
            }
            return venta;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Factura venta)
        {
            try
            {
                context.Factura.Add(venta);
                await context.SaveChangesAsync();
                return venta.Id;
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Factura venta)
        {
            if (id != venta.Id)
            {
                return BadRequest("No existe esa venta");
            }

            var ventas = context.Factura.Where(e => e.Id == id).FirstOrDefault();

            if (ventas == null)
            {
                return NotFound("No existe la venta buscada");
            }
            
            ventas.cliente = venta.cliente;
            ventas.FechaVenta = venta.FechaVenta;
            try
            {
                context.Factura.Update(ventas);
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
            var venta = context.Factura.Where(x => x.Id == id).FirstOrDefault();


            if (venta == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {


                context.Factura.Remove(venta);

                context.SaveChanges();
                return Ok($"El registro de {venta.Id} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }

    }
}

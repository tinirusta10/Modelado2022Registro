using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producto.BD;

namespace Modelado2022Registro.Server.Controllers
{
    [Route("api/Renglon")]
    [ApiController]
    public class RenglonController : ControllerBase
    {

        private readonly BDContext context;

        public RenglonController(BDContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto.BD.Data.Entidades.Renglon venta)
        {
            try
            {
                context.Renglon.Add(venta);
                await context.SaveChangesAsync();
                return venta.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto.BD.Data.Entidades.Renglon>> Get(int id)


        {

            var venta = await context.Renglon.FindAsync(id);


            if (venta == null)
            {
                return NotFound($"No existe venta de id: {id}");
            }
            return venta;
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var venta = context.Renglon.Where(x => x.Id == id).FirstOrDefault();


            if (venta == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {


                context.Renglon.Remove(venta);

                context.SaveChanges();
                return Ok($"El registro de {venta.Id} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Producto.BD.Data.Entidades.Renglon reng)
        {
            if (id != reng.Id)
            {
                return BadRequest("Datos Incorrectos");
            }

            var ventas = context.Renglon.Where(e => e.Id == id).FirstOrDefault();

            if (ventas == null)
            {
                return NotFound("No existe  el cliente buscada");
            }

            ventas.Factura = reng.Factura;
            ventas.Producto = reng.Producto;
            try
            {
                context.Renglon.Update(ventas);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }
    }
}

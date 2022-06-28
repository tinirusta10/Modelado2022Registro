using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.BD.Data.Entidades
{
    public class Productos
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public float PrecioProducto { get; set; }
        [Required]
        public int CodigoProducto { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public string ApellidoCliente { get; set; }
        [Required]
        public DateTime FechaVenta { get; set; }



    }
}

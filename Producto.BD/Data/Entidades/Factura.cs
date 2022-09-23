using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.BD.Data.Entidades
{
    public class Factura
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }

        


        public List <Renglon> Renglones { get; set; }



        public DateTime FechaVenta { get; set; }

    }
}
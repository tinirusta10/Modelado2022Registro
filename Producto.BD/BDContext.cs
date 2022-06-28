using Microsoft.EntityFrameworkCore;
using Producto.BD.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.BD
{
    public class BDContext: DbContext
    {

        public BDContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Productos> producto { get; set; }
    }
}

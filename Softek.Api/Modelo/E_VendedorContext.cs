using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Softtek.Api.Modelo
{
    public class E_VendedorContext : DbContext
    {
        public E_VendedorContext(DbContextOptions options):base(options)
        {

        }

        //public DbSet<E_Vendedor> E_Vendedores { get; set; }
    }
}

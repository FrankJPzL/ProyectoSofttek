using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Softtek.Entity.Modelo
{
    public class E_VendedorrContext : DbContext
    {
        public E_VendedorrContext(DbContextOptions<E_VendedorrContext> options):base(options)
        {

        }

        public DbSet<E_Vendedorr> E_Vendedores { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Softtek.Entity.Modelo
{
    public class E_VentasContext : DbContext
    {
        public E_VentasContext(DbContextOptions<E_VentasContext> options4) : base(options4)
        {

        }

        public DbSet<E_Ventas> E_Ventas { get; set; }
        public DbSet<E_AgenteComercial> E_AgenteComerciales { get; set; }
    }
}

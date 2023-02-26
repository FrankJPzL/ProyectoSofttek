using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Softtek.Entity.Modelo
{
    public class E_AgenteComercialContext : DbContext
    {

        public E_AgenteComercialContext(DbContextOptions<E_AgenteComercialContext> options3) : base(options3)
        {

        }

        public DbSet<E_AgenteComercial> E_AgenteComerciales { get; set; }
    }
}

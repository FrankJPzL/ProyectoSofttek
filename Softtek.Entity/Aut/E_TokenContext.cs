using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Softtek.Entity.Aut
{
   public class E_TokenContext : DbContext
    {
        public E_TokenContext(DbContextOptions<E_TokenContext> options2) : base(options2)
        {

        }

        public DbSet<E_Token> E_Tokens { get; set; }
    }
}

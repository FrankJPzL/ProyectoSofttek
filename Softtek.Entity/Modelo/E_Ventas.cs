using System;
using System.Collections.Generic;
using System.Text;

namespace Softtek.Entity.Modelo
{
    public class E_Ventas
    {
        public int id { get; set; }
        public int idvendedor { get; set; }
        public int idagente { get; set; }
        public string producto { get; set; }
        public decimal monto { get; set; }
    }
}

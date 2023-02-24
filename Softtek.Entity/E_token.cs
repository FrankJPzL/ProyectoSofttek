using System;
using System.Collections.Generic;
using System.Text;

namespace Softtek.Entity
{
    public class E_token
    {
        public Guid Id { get; set; }
        public string IdUsuario { get; set; }
        public string token { get; set; }        
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string sistema { get; set; }
               
        public string estado { get; set; }        
    }
}

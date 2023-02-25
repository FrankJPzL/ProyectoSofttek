using System;
using System.Collections.Generic;
using System.Text;

namespace Softtek.Entity.Aut
{
    public class E_Token
    {
        public int id { get; set; }
        public int? UsuarioId { get; set; }
        public string token { get; set; }
        public DateTime? generaciontoken { get; set; }
        public DateTime? expiraciontoken { get; set; }        
        public string estado { get; set; }
    }
}

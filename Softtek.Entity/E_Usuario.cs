using Softtek.Entity.Aut;
using System;

namespace Softtek.Entity
{
    public class E_Usuario
    {
        public int IdUsuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string ApellidosNombres { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string estado { get; set; }
        public E_Token? token { get; set; }
    }
}

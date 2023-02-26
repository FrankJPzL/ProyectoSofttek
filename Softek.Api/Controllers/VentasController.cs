using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softtek.Entity.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly E_VentasContext _context;
        

        public VentasController(E_VentasContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public List<E_Ventas> GetVentas()
        {
            return _context.E_Ventas.ToList();
        }
        [HttpPost]
        [Route("AddVentas")]
        public ActionResult AddVentas(E_Ventas model)
        {            
            _context.E_Ventas.Add(model);
            _context.SaveChanges();

            return Ok(new
            {
                codigo = 200,
                resultado = "Generado correctamente",
                data = "",
                idtoken = ""
            }); ;
        }

        [HttpPost]
        [Route("ListVentas")]
        public ActionResult ListVentas(E_AgenteComercial model)
        {
            
            List<E_Ventas> lista = _context.E_Ventas.ToList();
            List<Item> lista2 = new List<Item>();
            E_Ventas obItem = new E_Ventas();

            lista2 = (from c in _context.E_Ventas
                     join sc in _context.E_AgenteComerciales
                     on c.idagente equals sc.id
                     where (sc.apellidosnombres.StartsWith(model.apellidosnombres))
                     select new Item() { id=c.id, agente = sc.apellidosnombres, producto = c.producto , monto  = c.monto})
                     .ToList();


            return Ok(new
            {
                codigo = 200,
                resultado = lista2,
                data = "",
                idtoken = ""
            });


        }

        private class Item
        {
            public int id { get; set; }
            public string agente { get; set; }
            public string producto { get; set; }
            public decimal monto { get; set; }
        }
    }
}

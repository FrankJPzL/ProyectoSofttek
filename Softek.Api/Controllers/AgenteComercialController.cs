using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softtek.Entity.Modelo;
using Softtek.Api.Code;

namespace Softtek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Wrapper]
    public class AgenteComercialController : Controller
    {
        private readonly E_VentasContext _context;

        public AgenteComercialController(E_VentasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<E_AgenteComercial> GetVendedor()
        {
            return _context.E_AgenteComerciales.ToList();
        }

        [HttpPost]
        [Route("AddAgenteComercial")]
        public ActionResult AddAgenteComercial(E_AgenteComercial model)
        {
            
            _context.E_AgenteComerciales.Add(model);
            _context.SaveChanges();

            return Ok(new
            {
                codigo = 200,
                resultado = "Registrado correctamente",
                data = "",
                idtoken = ""
            });
        }

        [HttpPost]
        [Route("ListAgentes")]
        public ActionResult ListAgentes(E_AgenteComercial model)
        {
            List<E_AgenteComercial> lista = _context.E_AgenteComerciales.ToList();
            return Ok(new
            {
                codigo = 200,
                resultado = lista,
                data = "",
                idtoken = ""
            });

            
        }
    }
}

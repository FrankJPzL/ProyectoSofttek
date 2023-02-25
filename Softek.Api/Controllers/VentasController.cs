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
        private readonly E_VendedorrContext _context;

        public VentasController(E_VendedorrContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public List<E_Vendedorr> GetVendedor()
        {
            return _context.E_Vendedores.ToList();
        }
        [HttpPost]
        [Route("AddVendedor")]
        public ActionResult AddVendedor(E_Vendedorr model)
        {
            model.fecharegistro = DateTime.Now;
            _context.E_Vendedores.Add(model);
            _context.SaveChanges();
            return Created("api/Ventas/"+model.id, model);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softtek.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Softtek.Entity.Aut;

namespace Softek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : Controller
    {
       // private readonly IConfiguration configuration;
        private readonly E_TokenContext _context2;

        //public SeguridadController(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public SeguridadController(E_TokenContext context2)
        {
            _context2 = context2;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(E_Usuario usuario)
        {

            if(usuario.usuario != "fjacobe")
            {
                return Ok(new
                {
                    codigo = 400,
                    resultado = "El usuario no existe",
                    data = "NO_TOKEN"
                });
            }

            string lstr_token = GenerarTokenJWT(usuario);           
            string generate = Generate(usuario.token, lstr_token);
           
            return Ok(new { codigo = 200,
                resultado = "Usuario o contraseña Incorrectos.Cuenta fue bloqueada" ,
                data = lstr_token,
                idtoken = generate
            });
        }
        private string GenerarTokenJWT(E_Usuario usuario)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("OLAh6Yh5KwNFvOqgltw7")
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.IdUsuario.ToString()),
                new Claim("nombre", usuario.ApellidosNombres),
                new Claim("codigo", usuario.IdUsuario.ToString()),
                //new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role,"Ventas")
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: "",
                    audience: "",
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas. .AddHours(24) ahorita 12 horas
                    expires: DateTime.UtcNow.AddMinutes(20)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }

        private string Generate(E_Token model, string lstr_token)
        {
            try
            {
                model.UsuarioId = 1;
                model.token = lstr_token;
                model.generaciontoken = DateTime.Now;
                model.expiraciontoken = DateTime.Now.AddHours(1);
                model.estado = "1";

                _context2.E_Tokens.Add(model);
                _context2.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
           
            return model.id.ToString();
        }
    }
}

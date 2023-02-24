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

namespace Softek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : Controller
    {
        private readonly IConfiguration configuration;

        public SeguridadController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(E_Usuario usuario)
        {

            if(usuario.usuario != "fjacobe")
            {
                return Ok(new
                {
                    codigo = "ERROR",
                    resultado = "Usuario o contraseña Incorrectos.Cuenta fue bloqueada",
                    data = "NO_TOKEN"
                });
            }

            string lstr_token = GenerarTokenJWT(usuario);

            return Ok(new { codigo = "200",
                resultado = "Usuario o contraseña Incorrectos.Cuenta fue bloqueada" ,
                data = lstr_token
            });
        }
        private string GenerarTokenJWT(E_Usuario usuario)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
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
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
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
    }
}

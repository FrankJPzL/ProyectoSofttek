using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtek.Api.Code
{
    public class Wrapper : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool resultado = false;
            string tokenkey = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if(tokenkey == "null")
            {
                tokenkey = string.Empty;
            }
            if (tokenkey == string.Empty)
            {
                resultado = false;
            }
            else //verificando si el token enviado es válido o no
            {                
                resultado = true;
            }


            if (resultado == false)
            {               
                context.Result = new BadRequestObjectResult(new
                {
                    codigo = -400,
                    resultado = "Token no activo",
                    data = "",
                    idtoken = ""
                });               
            }

            base.OnActionExecuting(context);
        }

        private void Ok(object p)
        {
            throw new NotImplementedException();
        }
    }
}

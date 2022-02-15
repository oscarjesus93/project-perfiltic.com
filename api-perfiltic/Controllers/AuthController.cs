using api_perfiltic.Helpers;
using api_perfiltic.Models.Auth;
using api_perfiltic.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Controllers
{
    
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly ApplicationDbContext applicationDbContext;
        public AuthController(IConfiguration iConfig, ApplicationDbContext applicationDbContext)
        {
            this.config = iConfig;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [Route("api/auth")]
        public async Task< ActionResult<Auth.Response> > auth ([FromBody] Auth.Request request)
        {
            try
            {
                Auth.Response response = new Auth.Response();

                //BUSCAMOS LOS DATOS EN LA BD
                var user = await applicationDbContext.pt_users.SingleOrDefaultAsync(user => user.email == request.email);

                if (user == null)
                {

                    return NotFound();
                }

                if(user.password != request.password)
                {
                    return NotFound();
                }

                //EN CASO DE ENCONTRAR AL USAURIO SE PROCEDE A AUTENTICAR
                string secret = this.config.GetValue<string>("secret");
                var jwtHelper = new JWTHelpers(secret);

                var token = jwtHelper.createToken(Convert.ToString(user.id_user));
                response.token = token;

                return Ok(response);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return NotFound();
            }
        } 




        //public object auth(Auth auth)
        //{
        //    string secret = this.config.GetValue<string>("secret");
        //    var jwtHelper = new JWTHelpers(secret);

        //    //validamos que el correo existe con la clave


        //    //

        //}

    }
}

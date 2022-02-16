using api_perfiltic.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_perfiltic.Entities;
using api_perfiltic.Models;
using Microsoft.EntityFrameworkCore;

namespace api_perfiltic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        public UserController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> post([FromBody] UserRequest userRequest)
        {
            UserResponse userResponse = new UserResponse();
            try
            {

                if(userRequest.name == "")
                {
                    userResponse.message = "El nombre del usaurio esta vacío";
                    return Ok(userResponse);
                }

                if (userRequest.email != userRequest.confirEmail)
                {
                    userResponse.message = "Los email no son iguales";
                    return Ok(userResponse);
                }

                if (userRequest.password != userRequest.confirPassword)
                {
                    userResponse.message = "las contrasenas no son iguales ";
                    return Ok(userResponse);
                }

                var user = mapper.Map<User>(userRequest);
                var userSearch = await applicationDbContext.pt_users.Where(u => u.email == userRequest.email).FirstOrDefaultAsync();

                if (userSearch != null)
                {
                    if (userSearch.email == userRequest.email)
                    {
                        userResponse.message = "El usuario que intenta crear ya esta creado";
                        return Ok(userResponse);
                    }
                }

                applicationDbContext.pt_users.Add(user);
                await applicationDbContext.SaveChangesAsync();

                var userSave = await applicationDbContext.pt_users.OrderByDescending(o => o.id_user).Take(1).FirstOrDefaultAsync();

                if (userSave != null)
                {
                    userResponse.message = "Registro completado";
                }
                else
                {
                    userResponse.message = "Ah ocurrido un error al guardar los datos";
                    return Ok(userResponse);
                }


                return userResponse;
            }
            catch (Exception ex)
            {
                userResponse.message = ex.Message.ToString();
                return StatusCode(500, userResponse);
                throw;
            }
        }


    }
}

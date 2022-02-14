using api_perfiltic.Entities;
using api_perfiltic.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Controllers
{    
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {

        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        public CategoriesController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return await applicationDbContext.pt_category.ToListAsync();
        }        
    }
}

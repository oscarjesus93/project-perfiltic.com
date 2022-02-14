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
using api_perfiltic.Models;

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
        [Route("api/categories/get")]
        public async Task<ActionResult<List<Entities.Category>>> Get()
        {
            return await applicationDbContext.pt_category.ToListAsync();
        } 
        
        [HttpGet("{id}")]
        [Route("api/GetId")]
        public async Task<ActionResult<Entities.Category>> GetId(int id)
        {
            return await applicationDbContext.pt_category.FirstOrDefaultAsync(c => c.id_category == id);
        }

        [HttpPost]
        [Route("api/category/save")]
        public async Task<ActionResult<Entities.Category>> Post(CategoryRequest request)
        {
            var category = mapper.Map<Entities.Category>(request);
            applicationDbContext.Add(category);
            await applicationDbContext.SaveChangesAsync();            

            return category;
        }
        
    }
}

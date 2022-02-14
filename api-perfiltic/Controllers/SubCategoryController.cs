using api_perfiltic.Entities;
using api_perfiltic.Models;
using api_perfiltic.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_perfiltic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public SubCategoryController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subcategory>>> Get()
        {
            return await applicationDbContext.pt_subcategory.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcategory>> Get(int id)
        {
            return await applicationDbContext.pt_subcategory.FirstOrDefaultAsync(sc => sc.id_subcategory == id);
        }

        [HttpPost]
        public async Task<ActionResult<Subcategory>> Post([FromBody] SubCategoryRequest request)
        {
            var subCategory = mapper.Map<Subcategory>(request);
            applicationDbContext.pt_subcategory.Add(subCategory);
            await applicationDbContext.SaveChangesAsync();

            return subCategory;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Subcategory>> Put(int id, [FromBody] SubCategoryRequest request)
        {
            var subCategory = await applicationDbContext.pt_subcategory.FirstOrDefaultAsync(c => c.id_subcategory == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            mapper.Map(request, subCategory);

            applicationDbContext.Entry(subCategory).State = EntityState.Modified;

            await applicationDbContext.SaveChangesAsync();

            return subCategory;
        }

    }
}

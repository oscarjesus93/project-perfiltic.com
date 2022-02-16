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
    [Route("api/[controller]")]    
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
        //[Route("api/categories/get")]
        //public async Task<ActionResult<List<Entities.Category>>> Get()
        //{
        //    return await applicationDbContext.pt_category.ToListAsync();
        //}

        public async Task<ActionResult<List<CategoryResponse>>> Get()
        {

            try
            {
                List<CategoryResponse> categoryResponses = new List<CategoryResponse>();
                var listCategories = await applicationDbContext.pt_category.ToListAsync();

                categoryResponses = mapper.Map<List<CategoryResponse>>(listCategories);

                if(categoryResponses.Count == 0)
                {
                    return NotFound(new { message = "No tiene categorias registradas" });
                } else
                {
                    return Ok(categoryResponses);
                }                

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        [HttpGet("{id}")]
        //[Route("api/GetId")]
        public async Task<ActionResult<CategoryResponse>> GetId(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            try
            {
                var category = await applicationDbContext.pt_category.FirstOrDefaultAsync(c => c.id_category == id);

                categoryResponse = mapper.Map<CategoryResponse>(category);

                if(categoryResponse == null)
                {

                    return NotFound(new { message = "Categoria no registrada" });

                } else
                {
                    return Ok(categoryResponse);
                }
            
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        [HttpPost]
        //[Route("api/category/save")]
        public async Task<ActionResult<CategoryResponse>> Post(CategoryRequest request)
        {

            try
            {
                if(request.name == "")
                {
                    return Ok(new { message = "El nombre es obligatorio" });
                }


                CategoryResponse categoryResponse = new CategoryResponse();
                var category = mapper.Map<Category>(request);
                applicationDbContext.Add(category);
                var categorySave = await applicationDbContext.SaveChangesAsync();

                categoryResponse = mapper.Map<CategoryResponse>(categorySave);

                return categoryResponse;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task< ActionResult<CategoryResponse> > Put(int id, [FromBody] CategoryRequest request)
        {
            try
            {
                CategoryResponse categoryResponse = new CategoryResponse();

                if (request.name == "")
                {
                    return Ok(new { message = "El nombre es obligatorio" });
                }

                var category = await applicationDbContext.pt_category.FirstOrDefaultAsync(c => c.id_category == id);

                if (category == null)
                {
                    return NotFound(new { message = "Categoria no encontrada" });
                }

                mapper.Map(request, category);
                applicationDbContext.Entry(category).State = EntityState.Modified;
                await applicationDbContext.SaveChangesAsync();

                var categoryUpdate = await applicationDbContext.pt_category.FirstOrDefaultAsync(c => c.id_category == id);
                categoryResponse = mapper.Map<CategoryResponse>(categoryUpdate);

                return categoryResponse;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }
        
    }
}

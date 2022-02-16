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
    //[Authorize]
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
        public async Task<ActionResult<List<SubCategoryResponse>>> Get()
        {
            try
            {
                List<SubCategoryResponse> subCategoryResponses = new List<SubCategoryResponse>();
                var listSubCategory = await applicationDbContext.pt_subcategory.ToListAsync();

                subCategoryResponses = mapper.Map<List<SubCategoryResponse>>(listSubCategory.Select(sb => new SubCategoryResponse
                {
                    id_subcategory = sb.id_subcategory,
                    description = sb.description,
                    category = this.findCategory(sb.id_category)
                }).ToList());

                if(subCategoryResponses.Count == 0)
                {
                    return NotFound(new { message = "No tiene categorias registradas" });
                } else
                {
                    return Ok(subCategoryResponses);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
            //return await applicationDbContext.pt_subcategory.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryResponse>> Get(int id)
        {
            try
            {
                SubCategoryResponse subCategoryResponse = new SubCategoryResponse();
                var subCategory = await applicationDbContext.pt_subcategory.FirstOrDefaultAsync(sc => sc.id_subcategory == id);

                subCategoryResponse = mapper.Map<SubCategoryResponse>(subCategory);

                if(subCategoryResponse == null)
                {
                    return NotFound(new { message = "Sub categoria no registrada"  });
                } else
                {
                    subCategoryResponse.category = this.findCategory(subCategory.id_category);
                    return Ok(subCategoryResponse);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryResponse>> Post([FromBody] SubCategoryRequest request)
        {
            try
            {
                SubCategoryResponse subCategoryResponse = new SubCategoryResponse();
                var subCategory = mapper.Map<Subcategory>(request);
                applicationDbContext.pt_subcategory.Add(subCategory);                

                await applicationDbContext.SaveChangesAsync();

                var categorySave = await applicationDbContext.pt_subcategory.OrderByDescending(sb => sb.id_subcategory).Take(1).FirstOrDefaultAsync();

                subCategoryResponse = mapper.Map<SubCategoryResponse>(categorySave);
                subCategoryResponse.category = this.findCategory(request.id_category);

                return Ok(subCategoryResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Subcategory>> Put(int id, [FromBody] SubCategoryRequest request)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        protected CategoryResponse findCategory(int idCategory)
        {
            CategoryResponse categoryResponse = new CategoryResponse();

            var category = applicationDbContext.pt_category.Find(idCategory);

            categoryResponse = mapper.Map<CategoryResponse>(category);


            return categoryResponse;
        }

    }
}

using api_perfiltic.Utilities;
using api_perfiltic.Entities;
using api_perfiltic.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_perfiltic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;
        public ProductController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<ProductResponse> > Get(int id)
        {
            try
            {
                ProductResponse response = new ProductResponse();

                var producto = await applicationDbContext.pt_products.FirstOrDefaultAsync(f => f.id_product == id);

                response = this.ProductResponse(producto);

                return response;
            }
            catch (Exception ex)
            {
                return NotFound();
                throw;
            }
        }

        [HttpPost]
        public async Task< ActionResult<ProductResponse> > Post([FromBody] ProductRequest productRequest )
        {
            try
            {
                ProductResponse productResponse = new ProductResponse();
                var product = mapper.Map<Product>(productRequest);
                applicationDbContext.pt_products.Add(product);
                await applicationDbContext.SaveChangesAsync();

                var productSave = await applicationDbContext.pt_products.OrderByDescending(o => o.id_product).Take(1).FirstOrDefaultAsync();

                productResponse = this.ProductResponse(productSave);
                return productResponse;
            }
            catch (Exception ex)
            {
                return NotFound();
                throw;
            }
        }

        [HttpGet]
        public async Task< ActionResult<List<ProductResponse>> > Get()
        {
            try
            {
                List<ProductResponse> productResponses = new List<ProductResponse>();
                var products = await applicationDbContext.pt_products.ToListAsync();

                productResponses = mapper.Map<List<ProductResponse>>( products.Select(p => new ProductResponse
                {
                    id_product = p.id_product,
                    name = p.name,
                    description = p.description,
                    price = p.price,
                    weight = p.weight,
                    subCategory = this.findSubCategory(p.id_subcategory),
                    currency = p.currency
                }).ToList());

                if(productResponses.Count == 0)
                {
                    return NotFound(new { message = "No tiene productos registrados" });
                } else
                {
                    return Ok(productResponses);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }

        [HttpGet]
        [Route("searach")]
        public async Task< ActionResult<List<ProductResponse>> > GetForCategry([FromQuery] ProductSubCategoryRequest productRequest)
        {
            try
            {
                List<ProductResponse> productResponse = new List<ProductResponse>();
                var products = await applicationDbContext.pt_products.Where(p => p.id_subcategory == productRequest.id_subcategory).ToListAsync();

                productResponse = mapper.Map<List<ProductResponse>>(products.Select(p => new ProductResponse
                {
                    id_product = p.id_product,
                    name = p.name,
                    description = p.description,
                    price = p.price,
                    weight = p.weight,
                    subCategory = this.findSubCategory(productRequest.id_subcategory),
                    currency = p.currency
                }).ToList());

                if (productResponse.Count == 0)
                {
                    return NotFound(new { message = "No tiene productos registrados" });
                }
                else
                {
                    return Ok(productResponse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
                throw;
            }
        }



        protected ProductResponse ProductResponse(Product product)
        {
            try
            {
                ProductResponse productRes = new ProductResponse();                

                productRes = mapper.Map<ProductResponse>(product);

                productRes.subCategory = findSubCategory(product.id_subcategory);

                return productRes;
            }
            catch (Exception ex)
            {
                string m = ex.Message.ToString();
                throw;
            }
        }

        protected  SubCategoryResponse findSubCategory(int idCategory)
        {
            SubCategoryResponse categoryResponse = new SubCategoryResponse();

            var subCategory = applicationDbContext.pt_subcategory.Find(idCategory);
            categoryResponse = mapper.Map<SubCategoryResponse>(subCategory);

            var category = applicationDbContext.pt_category.Find(subCategory.id_category);
            categoryResponse.category = mapper.Map<CategoryResponse>(category);

            return categoryResponse;
        }


    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_perfiltic.Models;
using api_perfiltic.Entities;

namespace api_perfiltic.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryRequest>()
                .ReverseMap();

            CreateMap<CategoryRequest, Category>()
                .ReverseMap();

            CreateMap<Category, CategoryResponse>()
                .ReverseMap();

            CreateMap<CategoryResponse, Category>()
                .ReverseMap();

            CreateMap<Subcategory, SubCategoryRequest>()
                .ReverseMap();

            CreateMap<SubCategoryRequest, Subcategory>()
                .ReverseMap();

            CreateMap<Subcategory, SubCategoryResponse>()
                .ReverseMap();
            CreateMap<SubCategoryResponse, Category>()
                .ReverseMap();

            CreateMap<Product, ProductRequest>()
                .ReverseMap();

            CreateMap<ProductRequest, Product>()
                .ReverseMap();

            CreateMap<ProductResponse, Product>()
                .ReverseMap();

            CreateMap<Product, ProductResponse>()
                .ReverseMap();

            CreateMap<User, UserRequest>()
                .ReverseMap();

            CreateMap<UserRequest, User>()
                .ReverseMap();
        }
    }
}

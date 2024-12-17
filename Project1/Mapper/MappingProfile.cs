using AutoMapper;
using Project1.DTOs;
using Project1.Models;

namespace Project1.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>().ReverseMap();

            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();

            CreateMap<ProductCategoryDTO, ProductCategory>().ReverseMap();
        }
    }
}
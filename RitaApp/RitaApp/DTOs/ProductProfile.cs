using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}

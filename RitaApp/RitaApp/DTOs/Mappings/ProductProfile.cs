using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Mappings
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

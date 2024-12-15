using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();
        }
    }
}

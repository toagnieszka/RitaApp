using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Mappings
{
    public class ProductCardProfile : Profile
    {
        public ProductCardProfile()
        {
            CreateMap<ProductCard, ProductCardDto>();
            CreateMap<CreateProductCardDto, ProductCard>();
        }
    }
}

using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs
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

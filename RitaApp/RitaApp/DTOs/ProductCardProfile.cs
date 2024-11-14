using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class ProductCardProfile : Profile
    {
        public ProductCardProfile()
        {
            CreateMap<ProductCard, ProductCardDto>();
        }
    }
}

using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Mappings
{
    public class ProductCardProfile : Profile
    {
        public ProductCardProfile()
        {
            CreateMap<ProductCard, ProductCardDto>();

            CreateMap<CreateProductCardDto, ProductCard>();

            CreateMap<UpdateProductCardDto, ProductCard>();
        }
    }
}

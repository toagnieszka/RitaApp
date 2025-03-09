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

            CreateMap<CreateProductCardDto, ProductCard>()
				 .ForMember(x => x.Categories, y => y.MapFrom(z => z.CategoryIds));

			CreateMap<int, Category>()
		   .ForMember(x => x.Id, y => y.MapFrom(z => z));

			CreateMap<UpdateProductCardDto, ProductCard>()
				.ForMember(x => x.Categories, y => y.MapFrom(z => z.CategoryIds)); 
        }
    }
}

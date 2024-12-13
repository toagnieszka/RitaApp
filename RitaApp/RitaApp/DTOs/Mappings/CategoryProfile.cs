using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>();
        }
    }
}

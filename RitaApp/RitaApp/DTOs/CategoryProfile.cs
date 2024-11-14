using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
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

using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.Services
{
    public interface ICategoryService 
    {
        public Task<List<CategoryDto>> GetAll();
        public Task<CategoryDto> Create(CreateCategoryDto createCategoryDto);
    }
}

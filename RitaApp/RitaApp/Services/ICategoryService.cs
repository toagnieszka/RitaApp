using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface ICategoryService 
    {
        public Task<List<CategoryDto>> GetAll();
        public Task<CategoryDto> Create(CreateCategoryDto createCategoryDto);
    }
}

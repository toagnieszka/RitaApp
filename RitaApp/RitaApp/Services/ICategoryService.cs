using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface ICategoryService 
    {
        public Task<List<CategoryDto>> GetAll();
        public Task<CategoryDto> GetById(int id);
        public Task<CategoryDto> Create(CreateCategoryDto createCategoryDto);
        public Task<CategoryDto> Update(UpdateCategoryDto updateCategoryDto);
        public Task Delete(int id);
    }
}

using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface ICategoryService 
    {
        public Task<List<CategoryDto>> GetAll();
    }
}

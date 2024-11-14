using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category> Create(Category category);
    }
}

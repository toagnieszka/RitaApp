using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RitaAppDbContext _context;
        public CategoryRepository(RitaAppDbContext context) 
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public Task<List<Category>> GetAll()
        {
            var categories = _context.Categories.ToListAsync();
            return categories;
        }
    }
}

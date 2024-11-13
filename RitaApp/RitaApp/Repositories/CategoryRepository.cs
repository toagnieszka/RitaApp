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

        public Task<List<Category>> GetAll()
        {
            var categories = _context.Categories.ToListAsync();
            return categories;
        }
    }
}

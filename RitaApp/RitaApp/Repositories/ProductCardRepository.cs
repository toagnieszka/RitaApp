using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class ProductCardRepository : IProductCardRepository
    {
        private readonly RitaAppDbContext _context;
        public ProductCardRepository(RitaAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<ProductCard>> GetAll()
        {
            var productCards = await _context.ProductCards.ToListAsync();
            return productCards;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(RitaAppDbContext context, ILogger<Repository<Product>> logger) : base(context, logger)
		{

		}
	
		public async Task<List<Product>> GetAll(string? searchText)
		{

			var query = _context.Products.AsQueryable();

			if (!string.IsNullOrEmpty(searchText))
			{
				query = query.Where(n => n.ProductCard.Name.Contains(searchText.ToLower()));
			}

			return await query
				.Include(pt => pt.ProductCard.Categories)
				.Include(pt => pt.ProductCard)
				.ThenInclude(pt => pt.Unit)
				.Include(pt => pt.Magazine)
				.ToListAsync();
		}
	}
}

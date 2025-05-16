using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;
using System.Linq;

namespace RitaApp.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(RitaAppDbContext context, ILogger<Repository<Product>> logger) : base(context, logger)
		{

		}

		public async Task<List<Product>> GetAll(string? searchByName, string? categories, string? magazine, float? amount, string? unit, Status? status, DateTime? expireDateFrom, DateTime? expireDateTo)
		{

			var query = _context.Products.AsQueryable();

			if (!string.IsNullOrEmpty(searchByName))
			{
				query = query.Where(p => p.ProductCard.Name.Contains(searchByName.ToLower()));
			}

            if (!string.IsNullOrEmpty(categories))
            {
                query = query.Where(p => p.ProductCard.Categories.Any(c => c.Name.ToLower().Contains(categories.ToLower()))); 
            }

            if (!string.IsNullOrEmpty(magazine))
            {
                query = query.Where(p => p.Magazine.Name.Contains(magazine.ToLower()));
            }

            if (amount.HasValue)
			{
				query = query.Where(p => p.Amount == amount);
			}

            if (!string.IsNullOrEmpty(unit))
            {
                query = query.Where(p => p.ProductCard.Unit.Name.Contains(unit.ToLower()));
            }

            if (status.HasValue)
			{
				query = query.Where(p => p.Status == status);
			}

			if (expireDateFrom.HasValue)
			{
				query = query.Where(p => p.ExpireDate >= expireDateFrom);
			}

			if (expireDateTo.HasValue)
			{
				query = query.Where(p => p.ExpireDate <= expireDateTo);
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

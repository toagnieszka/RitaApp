using Microsoft.EntityFrameworkCore;
using RitaApp.Data.Models;
using RitaApp.Data;
using RitaApp.DTOs;
using System.Reflection.Metadata;
using RitaApp.Exceptions;

namespace RitaApp.Repositories
{
	public class ProductCardRepository : Repository<ProductCard>, IProductCardRepository 
	{
		public ProductCardRepository(RitaAppDbContext context, ILogger<Repository<ProductCard>> logger) :base(context, logger)
		{
			
		}

		public async Task<List<ProductCard>> GetAll()
		{
			return await _context.ProductCards
				.Include(pt => pt.Unit)
				.Include(pt => pt.Categories)
				.ToListAsync();
		}

		public async Task<ProductCard> Create(ProductCard productCard)
		{
			var productcards = await _context.ProductCards.FirstOrDefaultAsync(x => x.Name == productCard.Name);
			if (productcards is not null)
			{
				productCard!.Id = 0;
				return productCard;
			}

			var categoryIds = productCard!.Categories!.Select(x => x.Id).ToList();
			var categories = new List<Category>();

			foreach(var id in categoryIds)
			{
				if(_context.Categories.FirstOrDefault(x => x.Id == id) is null)
				{
					continue;
				}
				categories.Add(_context.Categories.FirstOrDefault(x => x.Id == id)!);
			}

			productCard!.Categories = categories;

			await _context.ProductCards.AddAsync(productCard!);
			await _context.SaveChangesAsync();
			return productCard!;
		}

		public async Task<ProductCard> Update(ProductCard productCard)
		{
			var existingModel = await _context.ProductCards.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == productCard!.Id); 


			if (existingModel is null)
			{
				throw new NotFoundException($"Item with id: {productCard.Id} does not exist");
			}

			existingModel.Categories.Clear();
			await _context.SaveChangesAsync();

			var categoryIds = productCard!.Categories!.Select(x => x.Id).ToList();
			var categories = new List<Category>();

			foreach (var id in categoryIds)
			{
				if (_context.Categories.FirstOrDefault(x => x.Id == id) is null)
				{
					continue;
				}
				categories.Add(_context.Categories.FirstOrDefault(x => x.Id == id)!);
			}

			_context.ProductCards.Entry(existingModel).CurrentValues.SetValues(productCard);
			existingModel!.Categories = categories;
			_context.ProductCards.Entry(existingModel).Property(x => x.CreatedDate).IsModified = false;
			await _context.SaveChangesAsync();
			return existingModel;
		}
	}
}

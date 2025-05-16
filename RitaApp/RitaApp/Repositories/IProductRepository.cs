using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		public Task<List<Product>> GetAll(string? searchByName, string? categories, string? magazine, float? amount, string? unit, Status? status, DateTime? expireDateFrom, DateTime? expireDateTo);
	}
}

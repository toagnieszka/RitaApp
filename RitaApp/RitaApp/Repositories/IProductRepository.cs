using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		public Task<List<Product>> GetAll();
	}
}

using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
    }
}

using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IProductCardRepository
    {
        public Task<List<ProductCard>> GetAll();
        public Task<ProductCard> Create(ProductCard productCard);
    }
}

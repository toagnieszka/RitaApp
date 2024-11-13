using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll();
    }
}

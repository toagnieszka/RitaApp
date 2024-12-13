using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.Services
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll();
        public Task<ProductDto> GetById(int id);
        public Task<ProductDto> Create(CreateProductDto createProductDto);
    }
}

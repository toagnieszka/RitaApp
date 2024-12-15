using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll();
        public Task<ProductDto> GetById(int id);
        public Task<ProductDto> Create(CreateProductDto createProductDto);
        public Task<ProductDto> Update(UpdateProductDto updateProductDto);
        public Task Delete(int id);
    }
}

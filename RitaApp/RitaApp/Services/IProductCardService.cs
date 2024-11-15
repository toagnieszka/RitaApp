using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface IProductCardService
    {
        public Task<List<ProductCardDto>> GetAll();
        public Task<ProductCardDto> Create(CreateProductCardDto createProductCardDto);
    }
}

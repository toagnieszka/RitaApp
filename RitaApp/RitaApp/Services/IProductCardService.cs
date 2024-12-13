using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.Services
{
    public interface IProductCardService
    {
        public Task<List<ProductCardDto>> GetAll();
        public Task<ProductCardDto> GetById(int id);
        public Task<ProductCardDto> Create(CreateProductCardDto createProductCardDto);
    }
}

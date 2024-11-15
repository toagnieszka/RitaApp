using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class ProductCardService : IProductCardService
    {
        private readonly IProductCardRepository _productCardRepository;
        private readonly IMapper _mapper;

        public ProductCardService(
            IProductCardRepository productCardRepository,
            IMapper mapper) 
        {
            _productCardRepository = productCardRepository;
            _mapper = mapper;
        }

        public async Task<ProductCardDto> Create(CreateProductCardDto createProductCardDto)
        {
            var productCard = _mapper.Map<ProductCard>(createProductCardDto);
            productCard = await _productCardRepository.Create(productCard);
            return _mapper.Map<ProductCardDto>(productCard);
        }

        public async Task<List<ProductCardDto>> GetAll()
        {
            var productCards = await _productCardRepository.GetAll();
            var productCardsDto = _mapper.Map<List<ProductCardDto>>(productCards);
            return productCardsDto;
        }
    }
}

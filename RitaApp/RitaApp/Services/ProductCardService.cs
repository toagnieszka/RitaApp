using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class ProductCardService : IProductCardService
    {
        private readonly IRepository<ProductCard> productCardRepository;
        private readonly IMapper _mapper;

        public ProductCardService(
            IRepository<ProductCard> productCardRepository,
            IMapper mapper) 
        {
            this.productCardRepository = productCardRepository;
            _mapper = mapper;
        }

        public async Task<ProductCardDto> Create(CreateProductCardDto createProductCardDto)
        {
            var productCard = _mapper.Map<ProductCard>(createProductCardDto);
            productCard = await this.productCardRepository.Create(productCard);
            return _mapper.Map<ProductCardDto>(productCard);
        }

        public async Task<List<ProductCardDto>> GetAll()
        {
            var productCards = await this.productCardRepository.GetAll();
            var productCardsDto = _mapper.Map<List<ProductCardDto>>(productCards);
            return productCardsDto;
        }
    }
}

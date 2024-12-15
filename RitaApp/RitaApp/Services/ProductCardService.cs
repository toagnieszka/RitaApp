using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
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
        public async Task<List<ProductCardDto>> GetAll()
        {
            var productCards = await this.productCardRepository.GetAll();
            var productCardsDto = _mapper.Map<List<ProductCardDto>>(productCards);
            return productCardsDto;
        }

        public async Task<ProductCardDto> GetById(int id)
        {
            var productCard = await this.productCardRepository.GetById(id);
            var productCardDto = _mapper.Map<ProductCardDto>(productCard);
            return productCardDto;
        }

        public async Task<ProductCardDto> Create(CreateProductCardDto createProductCardDto)
        {
            var productCard = _mapper.Map<ProductCard>(createProductCardDto);
            productCard = await this.productCardRepository.Create(productCard);
            return _mapper.Map<ProductCardDto>(productCard);
        }

        public async Task<ProductCardDto> Update(UpdateProductCardDto updateProductCardDto)
        {
            var productCard = _mapper.Map<ProductCard>(updateProductCardDto);
            productCard = await this.productCardRepository.Update(productCard);
            return _mapper.Map<ProductCardDto>(productCard);
        }

        public Task Delete(int id)
        {
            return this.productCardRepository.Delete(id);
        }
    }
}

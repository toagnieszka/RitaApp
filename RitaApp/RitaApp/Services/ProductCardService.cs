using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class ProductCardService : IProductCardService
    {
        private readonly IProductCardRepository productCardRepository;
        private readonly IMapper _mapper;

        public ProductCardService(
            IMapper mapper,
            IProductCardRepository productCardRepository) 
        {
            this.productCardRepository = productCardRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductCardDto>> GetAll()
        {
            var productCards = await productCardRepository.GetAll();
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
            productCard = await productCardRepository.Create(productCard);
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

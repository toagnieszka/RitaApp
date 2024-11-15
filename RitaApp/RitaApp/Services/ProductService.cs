using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            product = await _productRepository.Create(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }
    }
}

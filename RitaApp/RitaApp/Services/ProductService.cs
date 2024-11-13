using AutoMapper;
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

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }
    }
}

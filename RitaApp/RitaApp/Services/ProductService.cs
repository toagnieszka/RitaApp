﻿using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Repositories;
using System.Reflection.Metadata;

namespace RitaApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
		private readonly IProductRepository productRepository;

		public ProductService(IMapper mapper, IProductRepository productRepository)
        { 

            _mapper = mapper;
			this.productRepository = productRepository;
        }
        public async Task<List<ProductDto>> GetAll(string? searchText)
        {
            var products = await productRepository.GetAll(searchText);
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await this.productRepository.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<ProductDto> Create(CreateProductDto createProductDto)
        {
			var product = _mapper.Map<Product>(createProductDto);
            product = await this.productRepository.Create(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Update(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            product = await this.productRepository.Update(product);
            return _mapper.Map<ProductDto>(product);
        }

        public Task Delete(int id)
        {
            return this.productRepository.Delete(id);
        }
    }
}

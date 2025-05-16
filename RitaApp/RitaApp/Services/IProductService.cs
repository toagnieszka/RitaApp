using RitaApp.Data.Models;
using RitaApp.Data;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll(string? searchByName, string? categories,string? magazine, float? amount, string? unit, Status? status, DateTime? expireDateFrom, DateTime? expireDateTo);
        public Task<ProductDto> GetById(int id);
        public Task<ProductDto> Create(CreateProductDto createProductDto);
        public Task<ProductDto> Update(UpdateProductDto updateProductDto);
        public Task Delete(int id);
    }
}

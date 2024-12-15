
using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(
            IRepository<Category> categoryRepository,
            IMapper mapper) 
        {
            this.categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await this.categoryRepository.GetAll();
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDtos;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await this.categoryRepository.GetById(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<CategoryDto> Create(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            category = await this.categoryRepository.Create(category);
            return _mapper.Map<CategoryDto>(category); 
        }

        public async Task<CategoryDto> Update(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            category = await this.categoryRepository.Update(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public Task Delete(int id)
        {
            return this.categoryRepository.Delete(id);
        }
    }
}

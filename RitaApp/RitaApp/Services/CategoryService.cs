
using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Create(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            category = await _categoryRepository.Create(category);
            return _mapper.Map<CategoryDto>(category); 
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDtos;
        }
    }
}

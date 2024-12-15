using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var projectsDtos = await _categoryService.GetAll();
            return Ok(projectsDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById([FromRoute] int id)
        {
            var categoryDto = await _categoryService.GetById(id);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var categoryDto = await _categoryService.Create(createCategoryDto);
            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var categoryDto = await _categoryService.Update(updateCategoryDto);
            return Ok(categoryDto);
        }
    }
}

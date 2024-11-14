using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
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

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var categoryDto = await _categoryService.Create(createCategoryDto);
            return Ok(categoryDto);
        }
    }
}

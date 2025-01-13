using FluentValidation;
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
        private readonly IValidator<CreateCategoryDto> _createCategoryDtoValidator;
        private readonly IValidator<UpdateCategoryDto> _updateCategoryDtoValidator;

        public CategoriesController(
            ICategoryService categoryService,
            IValidator<CreateCategoryDto> createCategoryDtoValidator,
            IValidator<UpdateCategoryDto> updateCategoryDtoValidator,
            ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _createCategoryDtoValidator = createCategoryDtoValidator;
            _updateCategoryDtoValidator = updateCategoryDtoValidator;
            logger.LogInformation("We are in categories");
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
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            _createCategoryDtoValidator.ValidateAndThrow(createCategoryDto);
            var categoryDto = await _categoryService.Create(createCategoryDto);
            return Ok(categoryDto);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            _updateCategoryDtoValidator.ValidateAndThrow(updateCategoryDto);
            var categoryDto = await _categoryService.Update(updateCategoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _categoryService.Delete(id);
            return NoContent();
        }
    }
}

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
    public class ProductCardsController : ControllerBase
    {
        private readonly IProductCardService _productCardService;
        private readonly IValidator<CreateProductCardDto> _createProductCardDtoValidator;

        public ProductCardsController (
            IProductCardService productCardService,
            IValidator<CreateProductCardDto> createProductCardDtoValidator)
        {
            _productCardService = productCardService;
            _createProductCardDtoValidator = createProductCardDtoValidator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCardDto>>> GetAll()
        {
            var productCardsDto = await _productCardService.GetAll();
            return Ok(productCardsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCardDto>> GetById([FromRoute] int id)
        {
            var productCardDto = await _productCardService.GetById(id);
            return Ok(productCardDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCardDto>> Create([FromBody] CreateProductCardDto createProductCardDto)
        {
            _createProductCardDtoValidator.ValidateAndThrow(createProductCardDto);
            var productCardDto = await _productCardService.Create(createProductCardDto);
            return Ok(productCardDto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductCardDto>> Update([FromBody] UpdateProductCardDto updateProductCardDto)
        {
            var productCardDto = await _productCardService.Update(updateProductCardDto);
            return Ok(productCardDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _productCardService.Delete(id);
            return NoContent();
        }
    }
}

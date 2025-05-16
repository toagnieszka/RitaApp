using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RitaApp.Data;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductDto> _createProductDtoValidator;
        private readonly IValidator<UpdateProductDto> _updateProductDtoValidator;

        public ProductsController(
            IProductService productService,
            IValidator<CreateProductDto> createProductDtoValidator,
            IValidator<UpdateProductDto> updateProductDtoValidator,
            ILogger<ProductsController> logger)
        {
            _productService = productService;
            _createProductDtoValidator = createProductDtoValidator;
            _updateProductDtoValidator = updateProductDtoValidator;
            logger.LogInformation("We are in products");
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll(
            [FromQuery] string? searchByName,
            [FromQuery] string? category,
            [FromQuery] string magazine,
            [FromQuery] float? amount,
            [FromQuery] string? unit,
            [FromQuery] Status? status,
            [FromQuery] DateTime? expireDateFrom,
			[FromQuery] DateTime? expireDateTo)
        {
            var productsDto = await _productService.GetAll(searchByName, category, magazine, amount, unit, status, expireDateFrom, expireDateTo);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
        {
            var productDto = await _productService.GetById(id);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductDto createProductDto)
        {
            _createProductDtoValidator.ValidateAndThrow(createProductDto);
            var productDto = await _productService.Create(createProductDto);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] UpdateProductDto updateProductDto)
        {
            _updateProductDtoValidator.ValidateAndThrow(updateProductDto);
            var productDto = await _productService.Update(updateProductDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _productService.Delete(id);
            return NoContent();
        }
    }
}

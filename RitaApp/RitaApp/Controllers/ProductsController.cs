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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var productsDto = await _productService.GetAll();
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
        {
            var productDto = await _productService.GetById(id);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            var productDto = await _productService.Create(createProductDto);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update([FromBody] UpdateProductDto updateProductDto)
        {
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

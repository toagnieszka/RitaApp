using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
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

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductDto createProductDto)
        {
            var productDto = await _productService.Create(createProductDto);
            return Ok(productDto);
        }
    }
}

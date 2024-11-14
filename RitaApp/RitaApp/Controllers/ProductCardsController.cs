using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCardsController : ControllerBase
    {
        private readonly IProductCardService _productCardService;

        public ProductCardsController (IProductCardService productCardService)
        {
            _productCardService = productCardService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCardDto>>> GetAll()
        {
            var productCardsDto = await _productCardService.GetAll();
            return Ok(productCardsDto);
        }
    }
}

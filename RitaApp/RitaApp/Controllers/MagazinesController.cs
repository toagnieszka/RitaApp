using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinesController : ControllerBase
    {
        private readonly IMagazineService _magazinesService;

        public MagazinesController(IMagazineService magazineService)
        {
            _magazinesService = magazineService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MagazineDto>>> GetAll()
        {
            var magazineDtos = await _magazinesService.GetAll();
            return Ok(magazineDtos);
        }
    }
}

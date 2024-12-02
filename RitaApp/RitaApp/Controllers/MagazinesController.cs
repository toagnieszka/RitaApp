using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
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

        [HttpPost]
        public async Task<ActionResult> Create(CreateMagazineDto createMagazineDto)
        {
            var magazineDto = await _magazinesService.Create(createMagazineDto);
            return Ok(magazineDto);
        }
    }
}

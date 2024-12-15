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

        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineDto>> GetById([FromRoute] int id)
        {
            var magazineDto = await _magazinesService.GetById(id);
            return Ok(magazineDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateMagazineDto createMagazineDto)
        {
            var magazineDto = await _magazinesService.Create(createMagazineDto);
            return Ok(magazineDto);
        }

        [HttpPut]
        public async Task<ActionResult<MagazineDto>> Update([FromBody] UpdateMagazineDto updateMagazineDto)
        {
            var magazineDto = await _magazinesService.Update(updateMagazineDto);
            return Ok(magazineDto);
        }
    }
}

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
    public class MagazinesController : ControllerBase
    {
        private readonly IMagazineService _magazinesService;
        private readonly IValidator<CreateMagazineDto> _createMagazineDtoValidator;
        private readonly IValidator<UpdateMagazineDto> _updateMagazineDtoValidator;

        public MagazinesController(
            IMagazineService magazineService,
            IValidator<CreateMagazineDto> createMagazineDtoValidator,
            IValidator<UpdateMagazineDto> updateMagazineDtoValidator,
            ILogger<MagazinesController> logger)
        {
            _magazinesService = magazineService;
            _createMagazineDtoValidator = createMagazineDtoValidator;
            _updateMagazineDtoValidator= updateMagazineDtoValidator;
            logger.LogInformation("We are in magazines");
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
        public async Task<ActionResult<MagazineDto>> Create([FromBody] CreateMagazineDto createMagazineDto)
        {
            _createMagazineDtoValidator.ValidateAndThrow(createMagazineDto);
            var magazineDto = await _magazinesService.Create(createMagazineDto);
            return Ok(magazineDto);
        }

        [HttpPut]
        public async Task<ActionResult<MagazineDto>> Update([FromBody] UpdateMagazineDto updateMagazineDto)
        {
            _updateMagazineDtoValidator.ValidateAndThrow(updateMagazineDto);
            var magazineDto = await _magazinesService.Update(updateMagazineDto);
            return Ok(magazineDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _magazinesService.Delete(id);
            return NoContent();
        }
    }
}

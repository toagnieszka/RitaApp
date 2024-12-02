using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.Services;

namespace RitaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitsController(IUnitService unitService) 
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDto>>> GetAll()
        {
            var unitsDto = await _unitService.GetAll();
            return Ok(unitsDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUnitDto createUnitDto)
        {
            var unitDto = await _unitService.Create(createUnitDto);
            return Ok(unitDto);
        }
    }
}

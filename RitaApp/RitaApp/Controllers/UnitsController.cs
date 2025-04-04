﻿using FluentValidation;
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
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly IValidator<CreateUnitDto> _createUnitDtoValidator;
        private readonly IValidator<UpdateUnitDto> _updateUnitDtoValidator;

        public UnitsController(
            IUnitService unitService,
            IValidator<CreateUnitDto> createUnitDtoValidator,
            IValidator<UpdateUnitDto> updateUnitDtoValidator,
            ILogger<UnitsController> logger) 
        {
            _unitService = unitService;
            _createUnitDtoValidator = createUnitDtoValidator;
            _updateUnitDtoValidator = updateUnitDtoValidator;
            logger.LogInformation("We are in units");
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDto>>> GetAll()
        {
            var unitsDto = await _unitService.GetAll();
            return Ok(unitsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDto>> GetById([FromRoute] int id)
        {
            var unitDto = await _unitService.GetById(id);
            return Ok(unitDto);
        }

        [HttpPost]
        public async Task<ActionResult<UnitDto>> Create([FromBody] CreateUnitDto createUnitDto)
        {
            _createUnitDtoValidator.ValidateAndThrow(createUnitDto);
            var unitDto = await _unitService.Create(createUnitDto);
            return Ok(unitDto);
        }

        [HttpPut]
        public async Task<ActionResult<UnitDto>> Update([FromBody] UpdateUnitDto updateUnitDto)
        {
            _updateUnitDtoValidator.ValidateAndThrow(updateUnitDto);
            var unitDto = await _unitService.Update(updateUnitDto);
            return Ok(unitDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _unitService.Delete(id);
            return NoContent();
        }
    }
}

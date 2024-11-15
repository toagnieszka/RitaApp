using AutoMapper;
using Microsoft.Identity.Client;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitService(
            IUnitRepository unitRepository,
            IMapper mapper) 
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<UnitDto> Create(CreateUnitDto createUnitDto)
        {
            var unit = _mapper.Map<Unit>(createUnitDto);
            unit = await _unitRepository.Create(unit);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<List<UnitDto>> GetAll()
        {
            var units = await _unitRepository.GetAll();
            var unitsDto = _mapper.Map<List<UnitDto>>(units);
            return unitsDto;
        }
    }
}

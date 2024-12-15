using AutoMapper;
using Microsoft.Identity.Client;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> unitRepository;
        private readonly IMapper _mapper;

        public UnitService(
            IRepository<Unit> unitRepository,
            IMapper mapper) 
        {
            this.unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<List<UnitDto>> GetAll()
        {
            var units = await this.unitRepository.GetAll();
            var unitsDto = _mapper.Map<List<UnitDto>>(units);
            return unitsDto;
        }

        public async Task<UnitDto> GetById(int id)
        {
            var unit = await this.unitRepository.GetById(id);
            var unitDto = _mapper.Map<UnitDto>(unit);
            return unitDto;
        }

        public async Task<UnitDto> Create(CreateUnitDto createUnitDto)
        {
            var unit = _mapper.Map<Unit>(createUnitDto);
            unit = await this.unitRepository.Create(unit);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<UnitDto> Update(UpdateUnitDto updateUnitDto)
        {
            var unit = _mapper.Map<Unit>(updateUnitDto);
            unit = await this.unitRepository.Update(unit);
            return _mapper.Map<UnitDto>(unit);
        }
    }
}

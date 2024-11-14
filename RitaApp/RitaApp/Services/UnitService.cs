using AutoMapper;
using Microsoft.Identity.Client;
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

        public async Task<List<UnitDto>> GetAll()
        {
            var units = await _unitRepository.GetAll();
            var unitsDto = _mapper.Map<List<UnitDto>>(units);
            return unitsDto;
        }
    }
}

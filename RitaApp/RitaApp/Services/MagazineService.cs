using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IMagazineRepository _magazineRepository;
        private readonly IMapper _mapper;
        public MagazineService(
            IMagazineRepository magazineRepository,
            IMapper mapper) 
        {
            _magazineRepository = magazineRepository;
            _mapper = mapper;
        }

        public async Task<MagazineDto> Create(CreateMagazineDto createMagazineDto)
        {
            var magazine = _mapper.Map<Magazine>(createMagazineDto);
            magazine = await _magazineRepository.Create(magazine);
            return _mapper.Map<MagazineDto>(magazine);
        }

        public async Task<List<MagazineDto>> GetAll()
        {
            var magazines = await _magazineRepository.GetAll();
            var magazinesDto = _mapper.Map<List<MagazineDto>>(magazines);
            return magazinesDto;
        }
    }
}

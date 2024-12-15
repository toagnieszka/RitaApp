using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IRepository<Magazine> magazineRepository;
        private readonly IMapper _mapper;
        public MagazineService(
            IRepository<Magazine> magazineRepository,
            IMapper mapper) 
        {
            this.magazineRepository = magazineRepository;
            _mapper = mapper;
        }

        public async Task<List<MagazineDto>> GetAll()
        {
            var magazines = await this.magazineRepository.GetAll();
            var magazinesDto = _mapper.Map<List<MagazineDto>>(magazines);
            return magazinesDto;
        }

        public async Task<MagazineDto> GetById(int id)
        {
            var magazine = await this.magazineRepository.GetById(id);
            var magazineDto = _mapper.Map<MagazineDto>(magazine);
            return magazineDto;
        }

        public async Task<MagazineDto> Create(CreateMagazineDto createMagazineDto)
        {
            var magazine = _mapper.Map<Magazine>(createMagazineDto);
            magazine = await this.magazineRepository.Create(magazine);
            return _mapper.Map<MagazineDto>(magazine);
        }

        public async Task<MagazineDto> Update(UpdateMagazineDto updateMagazineDto)
        {
            var magazine = _mapper.Map<Magazine>(updateMagazineDto);
            magazine = await this.magazineRepository.Update(magazine);
            return _mapper.Map<MagazineDto>(magazine);
        }
    }
}

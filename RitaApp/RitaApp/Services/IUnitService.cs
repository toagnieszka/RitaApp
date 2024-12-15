using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface IUnitService
    {
        public Task<List<UnitDto>> GetAll();
        public Task<UnitDto> GetById(int id);
        public Task<UnitDto> Create(CreateUnitDto createUnitDto);
        public Task<UnitDto> Update(UpdateUnitDto updateUnitDto);
    }
}

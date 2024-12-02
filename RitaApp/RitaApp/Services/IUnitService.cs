using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.Services
{
    public interface IUnitService
    {
        public Task<List<UnitDto>> GetAll();
        public Task<UnitDto> Create(CreateUnitDto createUnitDto);
    }
}

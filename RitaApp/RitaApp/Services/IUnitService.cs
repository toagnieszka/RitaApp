using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface IUnitService
    {
        public Task<List<UnitDto>> GetAll();
    }
}

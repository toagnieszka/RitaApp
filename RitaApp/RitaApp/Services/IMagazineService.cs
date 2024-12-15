using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface IMagazineService
    {
        public Task<List<MagazineDto>> GetAll();
        public Task<MagazineDto> GetById(int id);
        public Task<MagazineDto> Create(CreateMagazineDto createMagazineDto);
        public Task<MagazineDto> Update(UpdateMagazineDto updateMagazineDto);
        public Task Delete(int id);
    }
}

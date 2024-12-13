using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> GetById(int id);
        public Task<UserDto> Create(CreateUserDto createUserDto);
    }
}

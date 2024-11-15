using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> Create(CreateUserDto createUserDto);
    }
}

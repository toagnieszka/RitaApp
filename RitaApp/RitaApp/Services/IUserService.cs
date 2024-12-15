using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.Services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetAll();
        public Task<UserDto> GetById(int id);
        public Task<UserDto> Create(CreateUserDto createUserDto);
        public Task<UserDto> Update(UpdateUserDto updateUserDto);
        public Task Delete(int id);
    }
}

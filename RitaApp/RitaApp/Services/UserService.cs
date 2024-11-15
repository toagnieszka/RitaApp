using AutoMapper;
using Microsoft.Identity.Client;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Create(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            user = await _userRepository.Create(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }
    }
}

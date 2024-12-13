using AutoMapper;
using Microsoft.Identity.Client;
using RitaApp.Data.Models;
using RitaApp.DTOs;
using RitaApp.DTOs.CreateDto;
using RitaApp.Repositories;

namespace RitaApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IRepository<User> userRepository,
            IMapper mapper) 
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await this.userRepository.GetAll();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return usersDto;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await this.userRepository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> Create(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            user = await this.userRepository.Create(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}

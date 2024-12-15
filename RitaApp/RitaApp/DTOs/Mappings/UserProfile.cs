using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>();
        }
    }
}

using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserDto>();
        }
    }
}

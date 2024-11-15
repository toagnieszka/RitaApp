using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class UnitProfile : Profile
    {
        public UnitProfile() 
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUnitDto, Unit>();
        }
    }
}

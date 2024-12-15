using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Mappings
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();

            CreateMap<CreateUnitDto, Unit>();

            CreateMap<UpdateUnitDto, Unit>();
        }
    }
}

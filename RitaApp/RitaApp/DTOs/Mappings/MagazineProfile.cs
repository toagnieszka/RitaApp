using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Mappings
{
    public class MagazineProfile : Profile
    {
        public MagazineProfile()
        {
            CreateMap<Magazine, MagazineDto>();

            CreateMap<CreateMagazineDto, Magazine>();

            CreateMap<UpdateMagazineDto, Magazine>();
        }
    }
}

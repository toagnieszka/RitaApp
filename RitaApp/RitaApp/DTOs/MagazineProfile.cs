using AutoMapper;
using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class MagazineProfile : Profile
    {
        public MagazineProfile()
        {
            CreateMap<Magazine, MagazineDto>();

            CreateMap<CreateMagazineDto, Magazine>();
        }
    }
}

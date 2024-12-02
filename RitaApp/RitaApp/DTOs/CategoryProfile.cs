﻿using AutoMapper;
using RitaApp.Data.Models;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>();
        }
    }
}

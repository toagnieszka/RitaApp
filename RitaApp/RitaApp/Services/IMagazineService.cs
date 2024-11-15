﻿using RitaApp.DTOs;

namespace RitaApp.Services
{
    public interface IMagazineService
    {
        public Task<List<MagazineDto>> GetAll();
        public Task<MagazineDto> Create(CreateMagazineDto createMagazineDto);
    }
}

﻿using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IMagazineRepository
    {
       public Task<List<Magazine>> GetAll();
    }
}

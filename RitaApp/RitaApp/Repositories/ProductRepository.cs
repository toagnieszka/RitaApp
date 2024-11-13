﻿using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RitaAppDbContext  _context;
        public ProductRepository(RitaAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}

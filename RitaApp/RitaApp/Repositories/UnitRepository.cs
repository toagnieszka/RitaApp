using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly RitaAppDbContext _context;
        public UnitRepository(RitaAppDbContext context) 
        {
            _context = context;
        }

        public async Task<Unit> Create(Unit unit)
        {
            await _context.Units.AddAsync(unit);
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task<List<Unit>> GetAll()
        {
            var units = await _context.Units.ToListAsync();
            return units;
        }
    }
}

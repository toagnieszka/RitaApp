using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private readonly RitaAppDbContext _context;

        public MagazineRepository(RitaAppDbContext context)
        {
            _context = context;
        }

        public async Task<Magazine> Create(Magazine magazine)
        {
            await _context.Magazines.AddAsync(magazine);
            await _context.SaveChangesAsync();
            return magazine;
        }

        public async Task<List<Magazine>> GetAll()
        {
            var magazines = await _context.Magazines.ToListAsync();
            return magazines;
        }
    }
}

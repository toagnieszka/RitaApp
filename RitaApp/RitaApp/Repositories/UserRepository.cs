using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RitaAppDbContext _context;
        public UserRepository(RitaAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}

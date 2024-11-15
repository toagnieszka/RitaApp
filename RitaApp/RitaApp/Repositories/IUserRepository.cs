using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> Create(User user);
    }
}

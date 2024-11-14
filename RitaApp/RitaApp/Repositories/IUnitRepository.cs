using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IUnitRepository
    {
        public Task<List<Unit>> GetAll();
    }
}

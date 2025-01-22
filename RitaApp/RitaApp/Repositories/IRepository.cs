using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        //Task<User> GetUserByEmail(string email);

		Task<T> Create(T model);

        Task<T> Update(T model);

        Task Delete(int id);
    }
}

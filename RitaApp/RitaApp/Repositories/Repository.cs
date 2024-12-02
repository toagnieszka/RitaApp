using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;

namespace RitaApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
        protected readonly RitaAppDbContext _context;
        private DbSet<T> models;

        public Repository(RitaAppDbContext context)
        {
            _context = context;
            models = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await models.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            var modelsList = await models.ToListAsync();
            return modelsList;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

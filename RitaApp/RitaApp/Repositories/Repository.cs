using Microsoft.EntityFrameworkCore;
using RitaApp.Data;
using RitaApp.Data.Models;
using RitaApp.Exceptions;

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
        public async Task<List<T>> GetAll()
        {
            var modelsList = await models.ToListAsync();
            return modelsList;
        }

        public async Task<T> GetById(int id)
        {
            var model = await models.FindAsync(id);

            if(model is null)
            {
                throw new NotFoundException($"Item with id: {id} does not exist");
            }

            return model;
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

        public async Task Update(T entity)
        {

        }
    }
}

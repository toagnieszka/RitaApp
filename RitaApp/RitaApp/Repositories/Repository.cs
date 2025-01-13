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
        private readonly ILogger<Repository<T>> Logger;

        public Repository(RitaAppDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            models = context.Set<T>();
            Logger = logger;
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
                Logger.LogError("Not found exception in repository");
                throw new NotFoundException($"Item with id: {id} does not exist");
            }

            return model;
        }

        public async Task<T> Create(T model)
        {
            await models.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> Update(T model)
        {
            var existingModel = await models.FindAsync(model.Id);
            

            if(existingModel is null)
            {
                Logger.LogError("Not found exception in repository");
                throw new NotFoundException($"Item with id: {model.Id} does not exist");
            }

            models.Entry(existingModel).CurrentValues.SetValues(model);
            models.Entry(existingModel).Property(x => x.CreatedDate).IsModified = false;
            await _context.SaveChangesAsync();
            return existingModel;
        }

        public async Task Delete(int id)
        {
            var existingModel = await models.FindAsync(id);


            if (existingModel is null)
            {
                Logger.LogError("Not found exception in repository");
                throw new NotFoundException($"Item with id: {id} does not exist");
            }

            models.Remove(existingModel);
            await _context.SaveChangesAsync();
        }
    }
}

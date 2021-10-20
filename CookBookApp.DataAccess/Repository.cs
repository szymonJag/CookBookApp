using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly CookBookAppContext context;
        private DbSet<T> entities;

        public Repository(CookBookAppContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            return context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            T entity = await entities.SingleOrDefaultAsync(x => x.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

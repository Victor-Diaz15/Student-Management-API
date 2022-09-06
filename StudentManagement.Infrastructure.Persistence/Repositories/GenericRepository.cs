using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Application.Interfaces.Repositories;
using StudentManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly AppDbContext _db;

        //Constructor
        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }

        //CRUD
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            try
            {
                return await _db.Set<Entity>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> props)
        {
            try
            {
                var query = _db.Set<Entity>().AsQueryable();

                foreach (string prop in props)
                {
                    query = query.Include(prop);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            try
            {
                return await _db.Set<Entity>().FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            try
            {
                await _db.Set<Entity>().AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public virtual async Task UpdateAsync(Entity entity, int id)
        {
            try
            {
                Entity entry = await _db.Set<Entity>().FindAsync(id);
                _db.Entry(entry).CurrentValues.SetValues(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            try
            {
                _db.Set<Entity>().Remove(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}

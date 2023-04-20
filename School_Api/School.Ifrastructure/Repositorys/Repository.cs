using Microsoft.EntityFrameworkCore;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School_Ifrastructure.Repository
{
    
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly SchooldbContext _schooldbContext;
      
        public Repository(SchooldbContext schooldbContext) 
        {
            _schooldbContext = schooldbContext;
           
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _schooldbContext.Set<T>().AddAsync(entity);
                await _schooldbContext.SaveChangesAsync();
                return  entity;
            }
            catch(DbUpdateException ex)
            {
                throw new Exception("Unable to add entity. Please check your input and try again.", ex);    
            }
        }

      

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _schooldbContext.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _schooldbContext.Set<T>();

                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

                return await query.FirstOrDefaultAsync(entity => entity.Id == id);
            }
            catch( Exception ex ) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            _schooldbContext.Set<T>().Update(entity);
            await _schooldbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _schooldbContext.Set<T>().Remove(entity);
            await _schooldbContext.SaveChangesAsync();

        }
    }
}

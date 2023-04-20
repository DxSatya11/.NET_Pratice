using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School_Domain.IRepository
{
    public interface IRepository<T> where T : class,IEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task UpdateAsync(T entity);
        //   Task DeleteAsync(IEnumerable<int> ids);
        Task DeleteAsync(T entity);
    }
}

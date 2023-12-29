using E_MovieTicket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_MovieTicket.Persistence.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task<T> DeleteAsync(int id);
    }
}

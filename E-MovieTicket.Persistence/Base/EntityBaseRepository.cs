using E_MovieTicket.Domain;
using E_MovieTicket.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace E_MovieTicket.Persistence.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly EMovieTicketDbContext _eMovieTicketDbContext;
        public EntityBaseRepository(EMovieTicketDbContext eMovieTicketDbContext)
        {
            _eMovieTicketDbContext = eMovieTicketDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _eMovieTicketDbContext.Set<T>().AddAsync(entity);
            await _eMovieTicketDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _eMovieTicketDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _eMovieTicketDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _eMovieTicketDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _eMovieTicketDbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _eMovieTicketDbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id) => await _eMovieTicketDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _eMovieTicketDbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _eMovieTicketDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            try
            {
                await _eMovieTicketDbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict here
                // You can reload the entity from the database and merge changes, or log the conflict, etc.
                // Example: Reload the entity
                var databaseEntity = await _eMovieTicketDbContext.Set<T>().FindAsync(id);
                _eMovieTicketDbContext.Entry(databaseEntity).Reload();
                throw; // rethrow the exception or handle as appropriate
            }
        }
    }
}

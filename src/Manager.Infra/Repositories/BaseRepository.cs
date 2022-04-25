using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T baseObject)
        {
            _context.Add(baseObject);
            await _context.SaveChangesAsync();

            return baseObject;
        }

        public virtual async Task<T> RemoveAsync(long id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }

            return obj;
        }

        public virtual async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>()
                         .AsNoTracking()
                         .Where(x => x.Id == id)
                         .FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
            => await _context.Set<T>()
                     .AsNoTracking()
                     .ToListAsync();

        public virtual async Task<T> UpdateAsync(T baseObject)
        {
            _context.Entry(baseObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return baseObject;
        }
    }
}
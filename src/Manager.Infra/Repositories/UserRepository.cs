using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower().Equals(email.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> SearchByEmailAsync(string email)
        {
            return await _context.Users.Where(x => x.Email.ToLower().Contains(email.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchByNameAsync(string name)
        {
            return await _context.Users.Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistsByEmail(string email)
            => await _context.Users.AnyAsync(x => x.Email == email);

        public async Task<bool> ExistsById(long id)
            => await _context.Users.AnyAsync(x => x.Id == id);
    }
}
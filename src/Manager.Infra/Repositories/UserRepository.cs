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
            var user = await _context.Users.Where(x => x.Email.ToLower().Equals(email.ToLower()))
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<User>> SearchByEmailAsync(string email)
        {
            var users = await _context.Users.Where(x => x.Email.ToLower().Contains(email.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<User>> SearchByNameAsync(string name)
        {
            var users = await _context.Users.Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<bool> ExistsByEmail(string email)
            => await _context.Users.AnyAsync(x => x.Email.Equals(email));

        public async Task<bool> ExistsById(long id)
            => await _context.Users.AnyAsync(x => x.Id.Equals(id));
    }
}
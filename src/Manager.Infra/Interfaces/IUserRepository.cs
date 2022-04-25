using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistsByEmail(string email);

        Task<bool> ExistsById(long id);

        Task<User> GetByEmailAsync(string email);

        Task<IEnumerable<User>> SearchByEmailAsync(string email);

        Task<IEnumerable<User>> SearchByNameAsync(string name);
    }
}
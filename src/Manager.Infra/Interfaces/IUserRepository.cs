using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> SearchByEmailAsync(string email);
        Task<IEnumerable<User>> SearchByNameAsync(string name);
    }
}

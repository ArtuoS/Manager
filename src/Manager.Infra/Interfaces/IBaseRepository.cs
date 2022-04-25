using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> CreateAsync(T baseObject);

        Task<T> UpdateAsync(T baseObject);

        Task<T> RemoveAsync(long id);

        Task<T> GetAsync(long id);

        Task<IEnumerable<T>> GetAsync();
    }
}
using Manager.Services.DTOs;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto userDto);
        Task<UserDto> UpdateAsync(UserDto userDto);
        Task RemoveAsync(long id);
        Task<UserDto> GetAsync(long id);
        Task<IEnumerable<UserDto>> GetAsync();
        Task<UserDto> GetByEmailAsync(string email);
        Task<IEnumerable<UserDto>> SearchByEmailAsync(string email);
        Task<IEnumerable<UserDto>> SearchByNameAsync(string name);
    }
}
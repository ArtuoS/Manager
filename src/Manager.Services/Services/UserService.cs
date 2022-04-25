using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Core.Extensions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTOs;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            if (await _userRepository.ExistsByEmail(userDto.Email))
                throw new DomainException("Já existe um usuário com este email.");

            var user = _mapper.Map<User>(userDto);
            user.Validate();

            var createUser = await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(createUser);
        }

        public async Task<UserDto> GetAsync(long id)
        {
            var user = await _userRepository.GetAsync(id);

            return (user != null && user.Id.IsIdValid()) ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            var users = await _userRepository.GetAsync();

            return users.Any() ? _mapper.Map<IEnumerable<UserDto>>(users) : null;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            return (user != null && user.Id.IsIdValid()) ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task RemoveAsync(long id)
        {
            if (!await _userRepository.ExistsById(id))
                throw new DomainException("Usuário não existe.");

            await _userRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<UserDto>> SearchByEmailAsync(string email)
        {
            var users = await _userRepository.SearchByEmailAsync(email);

            return users.Any() ? _mapper.Map<IEnumerable<UserDto>>(users) : null;
        }

        public async Task<IEnumerable<UserDto>> SearchByNameAsync(string name)
        {
            var users = await _userRepository.SearchByEmailAsync(name);

            return users.Any() ? _mapper.Map<IEnumerable<UserDto>>(users) : null;
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            if (!await _userRepository.ExistsById(userDto.Id))
                throw new DomainException("Usuário não existe.");

            var user = _mapper.Map<User>(userDto);
            user.Validate();

            var updatedUser = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
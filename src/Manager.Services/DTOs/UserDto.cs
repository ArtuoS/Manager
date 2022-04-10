using Manager.Core;

namespace Manager.Services.DTOs
{
    public class UserDto
    {
        public UserDto(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public UserDto()
        { }

        public long Id { get; set; } = Globals.InvalidId;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            _errors = new List<string>();
            Validate();
        }


        // This is the constructor for EFCore, the above constructor is for the model creation.
        protected User() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void SetName(string name)
        {
            Name = name;
            Validate();
        }

        public void SetPassword(string password)
        {
            Password = password;
            Validate();
        }

        public void SetEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override void Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            AddErrors(validation.Errors);
        }
    }
}
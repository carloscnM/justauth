using Microsoft.AspNetCore.Identity;

namespace justauth.src.Domain.Entities {
    public class User : IdentityUser {
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
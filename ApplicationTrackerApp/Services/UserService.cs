using ApplicationTrackerApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationTrackerApp.Services
{
    public class UserService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public void RegisterUser(User user, string plainTextPassword)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, plainTextPassword);
        }

        public bool ValidateUser(User user, string plainTextPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, plainTextPassword);
            return result == PasswordVerificationResult.Success;
        }

    }
}

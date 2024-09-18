using ApplicationTrackerApp.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationTrackerApp.Services
{
    public class UserService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly PasswordHasher<Login> _sessionKeyHasher;
        public UserService()
        {
            _passwordHasher = new PasswordHasher<User>();
            _sessionKeyHasher = new PasswordHasher<Login>();
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

        public void HashSessionKey(Login login, string sessionKey)
        {
            login.SessionKey = _sessionKeyHasher.HashPassword(login, sessionKey);
        }

        public bool ValidateSessionKey(Login login, string sessionKey)
        {
            var result = _sessionKeyHasher.VerifyHashedPassword(login, login.SessionKey, sessionKey);
            return result == PasswordVerificationResult.Success;
        }
    }
}

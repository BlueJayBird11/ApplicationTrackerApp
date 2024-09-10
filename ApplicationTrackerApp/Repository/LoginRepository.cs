using ApplicationTrackerApp.Data;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            this._context = context;
        }

        public string GenerateNewSessionKey(int userId)
        {
            // needs testing
            string sessionKey = Guid.NewGuid().ToString();
            var login = _context.Logins.Where(l => l.User.Id == userId).FirstOrDefault();

            if (login == null)
            {
                var newLogin = new Login()
                {
                    LastLoginDate = DateTime.UtcNow,
                    SessionKey = sessionKey,
                };

                _context.Logins.Add(newLogin);
                Save();
            }
            else
            {
                login.SessionKey = sessionKey;
                login.LastLoginDate = DateTime.UtcNow;
                login.ModifiedDate = DateTime.UtcNow;
                _context.Logins.Update(login);
                Save();
            }
            return sessionKey;
        }

        public Login GetLogin(int id)
        {
            return _context.Logins.Where(l => l.Id == id).FirstOrDefault();
        }

        public ICollection<Login> GetLogins()
        {
            return _context.Logins.ToList();
        }

        public bool LoginExists(int id)
        {
            return _context.Logins.Any(l => l.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return (saved > 0);
        }

        public bool SessionExpired(int id)
        {
            var login = this.GetLogin(id);
            DateTime currentTime = DateTime.UtcNow;
            return (currentTime - login.LastLoginDate).TotalHours >= 24 * 5;
        }
    }
}

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

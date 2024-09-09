using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface ILoginRepository
    {
        ICollection<Login> GetLogins();
        Login GetLogin(int id);
        bool LoginExists(int id);
        bool SessionExpired(int id);
        string GenerateNewSessionKey(int userId);
        bool Save();
    }
}

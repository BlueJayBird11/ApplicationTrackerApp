using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        bool UserExists(int id);
        bool Save();
    }
}

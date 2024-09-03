﻿using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        ICollection<JobApplication> GetUsersJobApplications(int userId);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool UserExists(int id);
        bool Save();
    }
}

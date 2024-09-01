using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IJobApplicationRepository
    {
        ICollection<JobApplication> GetJobApplications();
        JobApplication GetJobApplication(int id);
        bool JobApplicationExists(int id);
        bool Save();
    }
}

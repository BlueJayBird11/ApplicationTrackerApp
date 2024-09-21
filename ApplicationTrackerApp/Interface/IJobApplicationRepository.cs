using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IJobApplicationRepository
    {
        ICollection<JobApplication> GetJobApplications();
        JobApplication GetJobApplication(int id);
        bool JobApplicationExists(int id);
        User GetJobApplicationsUser(int jobApplicationId);
        bool CreateJobApplication(JobApplication jobApplication, int userId, int jobTypeId, int closedReasonId);
        bool UpdateJobApplication(JobApplication jobApplication, int jobTypeId, int closedReasonId);
        bool DeleteJobApplication(JobApplication jobApplication);
        bool Save();
    }
}

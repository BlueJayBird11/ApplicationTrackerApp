using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IJobTypeRepository
    {
        ICollection<JobType> GetJobTypes();
        JobType GetJobType(int id);
        bool JobTypeExists(int id);
        bool Save();
    }
}

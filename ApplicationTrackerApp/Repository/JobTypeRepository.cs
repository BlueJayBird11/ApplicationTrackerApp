using ApplicationTrackerApp.Data;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Repository
{
    public class JobTypeRepository : IJobTypeRepository
    {
        private readonly DataContext _context;

        public JobTypeRepository(DataContext context)
        {
            this._context = context;
        }

        public JobType GetJobType(int id)
        {
            return _context.JobTypes.Where(j => j.Id == id).FirstOrDefault();
        }

        public ICollection<JobType> GetJobTypes()
        {
            return _context.JobTypes.ToList();
        }

        public bool JobTypeExists(int id)
        {
            return _context.JobTypes.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return (saved > 0);
        }
    }
}

using ApplicationTrackerApp.Data;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTrackerApp.Repository
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly DataContext _context;

        public JobApplicationRepository(DataContext context)
        {
            this._context = context;
        }

        public JobApplication GetJobApplication(int id)
        {
            return _context.JobApplications.Where(j => j.Id == id).Include(j => j.JobType).Include(j => j.ClosedReason).FirstOrDefault();
        }

        public ICollection<JobApplication> GetJobApplications()
        {
            return _context.JobApplications.ToList();
        }

        public bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(j => j.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return (saved > 0);
        }
    }
}

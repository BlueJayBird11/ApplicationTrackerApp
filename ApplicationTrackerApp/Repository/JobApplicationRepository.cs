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

        public bool CreateJobApplication(JobApplication jobApplication, int userId, int jobTypeId, int closedReasonId)
        {
            var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            var jobType = _context.JobTypes.Where(j => j.Id == jobTypeId).FirstOrDefault();
            var closedReason = _context.ClosedReasons.Where(c => c.Id == closedReasonId).FirstOrDefault();

            jobApplication.User = user;
            jobApplication.JobType = jobType;
            jobApplication.ClosedReason = closedReason;

            _context.Add(jobApplication);
            return Save();
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

        public bool UpdateJobApplication(JobApplication jobApplication, int jobTypeId, int closedReasonId)
        {
            var jobType = _context.JobTypes.Where(j => j.Id == jobTypeId).FirstOrDefault();
            var closedReason = _context.ClosedReasons.Where(c => c.Id == closedReasonId).FirstOrDefault();

            jobApplication.JobType = jobType;
            jobApplication.ClosedReason = closedReason;

            _context.Update(jobApplication);
            return Save();
        }
    }
}

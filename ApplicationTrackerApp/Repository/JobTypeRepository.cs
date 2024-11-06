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

        public bool FillData()
        {
            if (!_context.JobTypes.Any())
            {
                var jobTypes = new List<JobType>()
                {
                    new JobType()
                    {
                        Name = "Full-Time"
                    },
                    new JobType()
                    {
                        Name = "Part-Time"
                    },
                    new JobType()
                    {
                        Name = "Internship"
                    },
                    new JobType()
                    {
                        Name = "Contract"
                    },
                    new JobType()
                    {
                        Name = "Temporary"
                    },
                    new JobType()
                    {
                        Name = "Freelance"
                    },
                    new JobType()
                    {
                        Name = "Seasonal"
                    },
                    new JobType()
                    {
                        Name = "On-Call"
                    },
                    new JobType()
                    {
                        Name = "Apprenticeship"
                    }
                };
                _context.JobTypes.AddRange(jobTypes);
                return Save();
            }
            return false;
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

using ApplicationTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTrackerApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<JobApplication> Applications { get; set; }
        public DbSet<ClosedReason> ClosedReasons { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

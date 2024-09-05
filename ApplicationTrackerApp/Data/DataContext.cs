using ApplicationTrackerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTrackerApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ClosedReason> ClosedReasons { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Login)
                .WithOne(l => l.User)
                .HasForeignKey<Login>(l => l.Id);
        }
    }
}

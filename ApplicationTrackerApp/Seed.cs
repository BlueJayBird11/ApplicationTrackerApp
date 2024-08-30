﻿using ApplicationTrackerApp.Data;
using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            // 'Not hiring' | 'Position already filled' | 'Looking for other people' | 'Declined by self' | 'Interview' | 'Accepted'
            if (!dataContext.ClosedReasons.Any())
            {
                var closedReasons = new List<ClosedReason>()
                {
                    new ClosedReason()
                    {
                        Name = "Not hiring"
                    },
                    new ClosedReason()
                    {
                        Name = "Position already filled"
                    },
                    new ClosedReason()
                    {
                        Name = "Looking for other people"
                    },
                    new ClosedReason()
                    {
                        Name = "Declined by self"
                    },
                    new ClosedReason()
                    {
                        Name = "Interview"
                    },
                    new ClosedReason()
                    {
                        Name = "Accepted"
                    }
                };
                dataContext.ClosedReasons.AddRange(closedReasons);
                dataContext.SaveChanges();
            }

            // 'Full-Time' | 'Part-Time' | 'Internship' | 'Contract' | ''
            if (!dataContext.JobTypes.Any())
            {
                var jobType = new List<JobType>()
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
            }

            if (!dataContext.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Email = "bluejay.test@gmail.com",
                        PasswordHash = "AppTrack",
                        SignUpDate = DateTime.Now,
                        Applications = new List<JobApplication>()
                        {
                            new JobApplication()
                            {

                            }
                        }
                    }
                };
            }
        }
    }
}

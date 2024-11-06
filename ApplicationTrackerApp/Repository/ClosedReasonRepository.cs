using ApplicationTrackerApp.Data;
using ApplicationTrackerApp.Interface;
using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Repository
{
    public class ClosedReasonRepository : IClosedReasonRepository
    {
        private readonly DataContext _context;

        public ClosedReasonRepository(DataContext context)
        {
            this._context = context;
        }

        public bool ClosedReasonExists(int id)
        {
            return _context.ClosedReasons.Any(c => c.Id == id);
        }

        public bool FillData()
        {
            if (!_context.ClosedReasons.Any())
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
                    },
                    new ClosedReason()
                    {
                        Name = "No reason given"
                    },
                    new ClosedReason()
                    {
                        Name = "Offer"
                    }
                };
                _context.ClosedReasons.AddRange(closedReasons);
                return Save();
            }
            return false;
        }

        public ClosedReason GetClosedReason(int id)
        {
            return _context.ClosedReasons.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<ClosedReason> GetClosedReasons()
        {
            return _context.ClosedReasons.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return (saved > 0);
        }
    }
}

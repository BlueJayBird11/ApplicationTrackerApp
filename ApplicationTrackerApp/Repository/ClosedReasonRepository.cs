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

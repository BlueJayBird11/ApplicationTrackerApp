using ApplicationTrackerApp.Models;

namespace ApplicationTrackerApp.Interface
{
    public interface IClosedReasonRepository
    {
        ICollection<ClosedReason> GetClosedReasons();
        ClosedReason GetClosedReason(int id);
        bool ClosedReasonExists(int id);
        bool FillData();
        bool Save();
    }
}

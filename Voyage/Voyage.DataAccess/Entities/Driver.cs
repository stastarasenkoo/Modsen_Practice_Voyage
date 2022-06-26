using Voyage.DataAccess.Entities.Enums;

namespace Voyage.DataAccess.Entities
{
    public class Driver
    {
        public int UserId { get; set; }

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }

        public virtual ICollection<Trip> Trips { get; set; } = null!;

        public virtual AppUser User { get; set; } = null!;
    }
}

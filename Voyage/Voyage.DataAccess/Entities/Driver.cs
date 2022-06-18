using Voyage.DataAccess.Enums;

namespace Voyage.DataAccess.Entities
{
    public class Driver
    {
        public int UserId { get; set; }

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }

        public ICollection<Trip> Trips { get; set; } = null!;

        public AppUser User { get; set; } = null!;
    }
}

using Voyage.DataAccess.Enums;

namespace Voyage.DataAccess.Models
{
    public class Driver
    {
        public int UserId { get; set; }

        public AppUser User { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategories DriverCategory { get; set; }

        public ICollection<Trip> Trips { get; set; } = null!;
    }
}

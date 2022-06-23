using Microsoft.AspNetCore.Identity;

namespace Voyage.DataAccess.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string? ThirdName { get; set; }

        public int TripsCount { get; set; }

        public virtual Passenger? Passenger { get; set; }

        public virtual Driver? Driver { get; set; }
    }
}

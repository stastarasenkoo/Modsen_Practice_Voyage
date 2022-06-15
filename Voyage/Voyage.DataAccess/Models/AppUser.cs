using Microsoft.AspNetCore.Identity;

namespace Voyage.DataAccess.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? ThirdName { get; set; }

        public int TripsCount { get; set; }

        public Passenger? Passenger { get; set; }

        public Driver? Driver { get; set; }
    }
}

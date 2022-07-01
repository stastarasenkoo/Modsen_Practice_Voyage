using Voyage.Common.Types;

namespace Voyage.Common.ResponseModels
{
    public class DriverDetailsResponse
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; } = null!;

        public string UserSecondName { get; set; } = null!;

        public string? UserThirdName { get; set; } = null!;

        public string UserPhoneNumber { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }
    }
}

using Voyage.Common.Enums;

namespace Voyage.Common.RequestModels
{
    public class UpdateDriverRequest
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string ThirdName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }
    }
}

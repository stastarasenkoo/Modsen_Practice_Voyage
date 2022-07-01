using Voyage.Common.Types;

namespace Voyage.Common.RequestModels.Driver
{
    public class UpdateDriverRequest : IDriverInfo
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string? ThirdName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }
    }
}

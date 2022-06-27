using Voyage.Common.Types;

namespace Voyage.Common.RequestModels
{
    public class CreateDriverRequest
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string SecondName { get; set; } = null!;

        public string? ThirdName { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }
    }
}

using Voyage.Common.RequestModels.Driver;

namespace Voyage.Tests.TestData.Driver
{
    public class TestDriverRequests
    {
        public static CreateDriverRequest Create =>
            new CreateDriverRequest
            {
                FirstName = "First",
                Password = "Password",
                SecondName = "Second",
                DriverCategory = Common.Types.DriverCategoryType.C,
                DrivingExperience = 5,
                Email = "user@m.com",
                PhoneNumber = "12-34-56",
                ThirdName = null,
                UserName = "User1"
            };

        public static UpdateDriverRequest Update =>
            new UpdateDriverRequest()
            {
                UserId = 1,
                FirstName = "First",
                SecondName = "Second",
                DriverCategory = Common.Types.DriverCategoryType.C,
                DrivingExperience = 10,
                Email = "user@mail.com",
                PhoneNumber = "12-34-56",
                ThirdName = null,
            };
    }
}

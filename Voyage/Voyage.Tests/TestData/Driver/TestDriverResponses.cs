using System.Collections.Generic;
using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Driver
{
    public class TestDriverResponses
    {
        public static DriverDetailsResponse Details =>
            new DriverDetailsResponse
            {
                UserId = 1,
                UserEmail = "user@m.com",
                UserFirstName = "First",
                UserSecondName = "Second",
                UserThirdName = null,
                UserPhoneNumber = "12-34-56",
                DriverCategory = Common.Types.DriverCategoryType.C,
                DrivingExperience = 5
            };

        public static DriverDetailsResponse? NullableDetails => Details;

        public static DriverShortInfoResponse ShortInfo =>
            new DriverShortInfoResponse
            {
                UserId = 1,
                UserFirstName = "First",
                UserSecondName = "Second",
                UserPhoneNumber = "12-34-56"
            };

        public static IEnumerable<DriverShortInfoResponse> ShortInfoList =>
            new List<DriverShortInfoResponse>
            {
                ShortInfo,
            };
    }
}

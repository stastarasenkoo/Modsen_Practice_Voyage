using System.Collections.Generic;
using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Passanger
{
    public class TestPassengerResponses
    {
        public static PassengerDetailsResponse Details =>
            new PassengerDetailsResponse
            {
                UserId = 1,
                Points = 1
            };

        public static PassengerDetailsResponse? NullableDetails => Details;

        public static PassengerShortInfoResponse ShortInfo =>
            new PassengerShortInfoResponse
            {
                UserId = 1,
                Points = 1
            };

        public static IEnumerable<PassengerShortInfoResponse> ShortInfoList =>
            new List<PassengerShortInfoResponse>
            {
                ShortInfo,
            };
    }
}

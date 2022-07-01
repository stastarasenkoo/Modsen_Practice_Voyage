using System.Collections.Generic;
using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Route
{
    public class TestRouteResponses
    {
        public static RouteDetailsResponse Details =>
            new RouteDetailsResponse()
            {
                Id = 1,
                StopsCount = 10,
                DestinationAddress = "Destination",
                DepartureAddress = "Departure",
                BasePrice = 10,
                Distance = 1000,
                Name = "Name"
            };

        public static RouteDetailsResponse? NullableDetails => Details;



        public static RouteShortInfoResponse ShortInfo =>
            new RouteShortInfoResponse
            {
                Id = 1,
                BasePrice = 10,
                Name = "Name"
            };

        public static IEnumerable<RouteShortInfoResponse> ShortInfoList =>
            new List<RouteShortInfoResponse>
            {
                ShortInfo,
            };
    }
}

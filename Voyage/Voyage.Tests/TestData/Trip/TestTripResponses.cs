using System;
using System.Collections.Generic;
using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Trip
{
    public static class TestTripResponses
    {
        public static TripDetailsResponse Details =>
            new()
            {
                Id = 1,
                RouteName = "Route name",
                DriverName = "Driver name",
                TransportNumber = "8682 AX-3",
                DepartureTime = new DateTime(2023, 7, 10),
                ArrivalTime = new DateTime(2023, 7, 18),
                FinalPrice = 100,
                Description = "desvription",
                FreeSeats = 10,
            };

        public static TripDetailsResponse? NullableDetails => Details;

        public static TripShortInfoResponse ShortInfo =>
            new()
            {
                Id = 1,
                DepartureTime = new DateTime(2023, 7, 15),
            };

        public static IEnumerable<TripShortInfoResponse> ShortInfoList =>
            new List<TripShortInfoResponse>
            {
                ShortInfo,
            };
    }
}

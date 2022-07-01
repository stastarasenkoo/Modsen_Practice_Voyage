using System;
using Voyage.Common.RequestModels.Trip;

namespace Voyage.Tests.TestData.Trip
{
    public static class TestTripRequests
    {
        public static CreateTripRequest Create =>
         new()
         {
             RouteId = 1,
             DriverId = 1,
             TransportId = 1,
             DepartureTime = new DateTime(2023, 7, 10),
             ArrivalTime = new DateTime(2023, 7, 18),
             FinalPrice = 100,
             Description = "desvription",
             FreeSeats = 10,
         };

        public static UpdateTripRequest Update =>
            new()
            {
                RouteId = 1,
                DriverId = 1,
                TransportId = 1,
                DepartureTime = new DateTime(2023, 7, 10),
                ArrivalTime = new DateTime(2023, 7, 18),
                FinalPrice = 90,
                Description = "new desvription",
                FreeSeats = 6,
            };
    }
}

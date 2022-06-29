using System;
using System.Collections.Generic;
using Voyage.Common.ResponseModels;

namespace Voyage.Tests.TestData.Tickets
{
    public class TestTicketResponses
    {
        public static TicketDetailsResponse Details =>
            new TicketDetailsResponse()
            {
                PassengerId = 1,
                PassengerName = "Name",
                Price = 10,
                TripId = 1,
                TripShortInfo = new TripShortInfoResponse()
                {
                    DepartureTime = DateTime.Now,
                    RouteName = "Route",
                }
            };

        public static TicketDetailsResponse? NullableDetails => Details;



        public static TicketShortInfoResponse ShortInfo =>
            new TicketShortInfoResponse
            {
                PassengerId = 1,
                Price = 10,
                RouteName = "Route",
                TripDate = DateTime.Now,
                TripId = 1,
            };

        public static IEnumerable<TicketShortInfoResponse> ShortInfoList =>
            new List<TicketShortInfoResponse>
            {
                ShortInfo,
            };
    }
}

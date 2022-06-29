using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Common.RequestModels;

namespace Voyage.Tests.TestData.Route
{
    public class TestRouteRequests
    {
        public static CreateRouteRequest Create =>
            new CreateRouteRequest()
            {
                BasePrice = 10,
                StopsCount = 10,
                DepartureAddress = "Departure",
                DestinationAddress = "Destination",
                Distance = 1000,
                Name = "Name"
            };

        public static UpdateRouteRequest Update =>
            new UpdateRouteRequest()
            {
                Id = 1,
                BasePrice = 10,
                StopsCount = 10,
                DepartureAddress = "Departure",
                DestinationAddress = "Destination",
                Distance = 1000,
                Name = "New"
            };
    }
}

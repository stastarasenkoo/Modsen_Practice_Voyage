using Voyage.Common.RequestModels.Ticket;

namespace Voyage.Tests.TestData.Tickets
{
    public class TestTicketRequests
    {
        public static TicketRequest Create =>
            new TicketRequest
            {
                PassengerId = 1,
                TripId = 1,
            };

        public static TicketRequest Delete =>
            new TicketRequest()
            {
                PassengerId = 1,
                TripId = 1,
            };

        public static TicketRequest GetDetails =>
            new TicketRequest()
            {
                PassengerId = 1,
                TripId = 1
            };

        public static TicketSearchRequest Get =>
            new TicketSearchRequest()
            {
                PassengerId = 1,
                TripId = 1,
            };


    }
}

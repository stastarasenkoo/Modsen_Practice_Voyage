using Voyage.Common.RequestModels;

namespace Voyage.Tests.TestData.Tickets
{
    public class TestTicketRequests
    {
        public static CreateTicketRequest Create =>
            new CreateTicketRequest
            {
                PassengerId = 1,
                TripId = 1,
            };

        public static DeleteTicketRequest Delete =>
            new DeleteTicketRequest()
            {
                PassengerId = 1,
                TripId = 1,
            };

        public static GetTicketDetailsRequest GetDetails =>
            new GetTicketDetailsRequest()
            {
                PassengerId = 1,
                TripId = 1
            };

        public static GetTicketsRequest Get =>
            new GetTicketsRequest()
            {
                PassengerId = 1,
                TripId = 1,
            };


    }
}

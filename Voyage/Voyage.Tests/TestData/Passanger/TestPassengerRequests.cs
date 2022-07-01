using Voyage.Common.RequestModels.Passenger;

namespace Voyage.Tests.TestData.Passanger
{
    public class TestPassengerRequests
    {
        public static PassengerRequest Create =>
           new PassengerRequest
           {
               UserId = 1,
               Points = 1,
           };

        public static PassengerRequest Update =>
            new PassengerRequest()
            {
                UserId = 1,
                Points = 5
            };
    }
}

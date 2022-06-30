using Voyage.Common.RequestModels;

namespace Voyage.Tests.TestData.Passanger
{
    public class TestPassengerRequests
    {
        public static CreatePassengerRequest Create =>
           new CreatePassengerRequest
           {
               UserId = 1,
               Points = 1,
           };

        public static UpdatePassengerRequest Update =>
            new UpdatePassengerRequest()
            {
                UserId = 1,
                Points = 5
            };
    }
}

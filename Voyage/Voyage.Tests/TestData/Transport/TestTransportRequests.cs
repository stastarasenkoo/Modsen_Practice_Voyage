using Voyage.Common.Types;
using Voyage.Common.RequestModels;

namespace Voyage.Tests.TestData.Transport
{
    public static class TestTransportRequests
    {
        public static CreateTransportRequest Create =>
            new CreateTransportRequest
            {
                Number = "number",
                Color = Color.White,
                SeatsCount = 1,
            };

        public static UpdateTransportRequest Update =>
            new UpdateTransportRequest()
            {
                Id = 1,
                Number = "number",
                Color = Color.White,
                PriceRate = 1.2,
            };
    }
}
